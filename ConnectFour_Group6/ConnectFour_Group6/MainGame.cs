using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group6
{
    public partial class MainGame : Form
    {
        private Board gameBoard;
        private Stacy stacy;
        private int mode;
        private Form1 form1;
        private bool depthSet = false;
        private SaveInfo saver;
        private int depth;
        public MainGame(int selector, Form1 form)
        {
            InitializeComponent();
            form1 = form;
            if (selector == 1)
            {
                //constructors and button handler
                saver = new SaveInfo();
                mode = 1;
                gameBoard = new Board(mode);
                stacy = new Stacy();
                setUpGame();
                Column1.MouseDown += placePiece;
                Column2.MouseDown += placePiece;
                Column3.MouseDown += placePiece;
                Column4.MouseDown += placePiece;
                Column5.MouseDown += placePiece;
                Column6.MouseDown += placePiece;
                Column7.MouseDown += placePiece;

                Column1.MouseEnter += setPreview;
                Column2.MouseEnter += setPreview;
                Column3.MouseEnter += setPreview;
                Column4.MouseEnter += setPreview;
                Column5.MouseEnter += setPreview;
                Column6.MouseEnter += setPreview;
                Column7.MouseEnter += setPreview;

                Column1.MouseLeave += clearPreview;
                Column2.MouseLeave += clearPreview;
                Column3.MouseLeave += clearPreview;
                Column4.MouseLeave += clearPreview;
                Column5.MouseLeave += clearPreview;
                Column6.MouseLeave += clearPreview;
                Column7.MouseLeave += clearPreview;
            }
            if (selector == 2)
            {

                Depth_box.Visible = false;
                WarningRtb.Visible = false;
                Depth_Lbl.Visible = false;
                Depth_box.Visible = false;
                mode = 2;
                gameBoard = new Board(mode);
                setUpGame();

                Column1.MouseDown += placePiece;
                Column2.MouseDown += placePiece;
                Column3.MouseDown += placePiece;
                Column4.MouseDown += placePiece;
                Column5.MouseDown += placePiece;
                Column6.MouseDown += placePiece;
                Column7.MouseDown += placePiece;

                Column1.MouseEnter += setPreview;
                Column2.MouseEnter += setPreview;
                Column3.MouseEnter += setPreview;
                Column4.MouseEnter += setPreview;
                Column5.MouseEnter += setPreview;
                Column6.MouseEnter += setPreview;
                Column7.MouseEnter += setPreview;

                Column1.MouseLeave += clearPreview;
                Column2.MouseLeave += clearPreview;
                Column3.MouseLeave += clearPreview;
                Column4.MouseLeave += clearPreview;
                Column5.MouseLeave += clearPreview;
                Column6.MouseLeave += clearPreview;
                Column7.MouseLeave += clearPreview;
            }

        }

        public MainGame()
        {

        }

        public void setUpGame()
        {
            //build board
            string name;
            char delim = '_';
            int posDelim;
            int col;
            int row;
            Cell c;

            foreach (var button in this.Controls.OfType<Button>())
            {
                if (button.Text == "")
                {
                    name = button.Name;

                    posDelim = name.IndexOf(delim);
                    row = Int32.Parse(name.Substring(posDelim + 1, 1));

                    name = name.Substring(posDelim + 2);
                    posDelim = name.IndexOf(delim);
                    col = Int32.Parse(name.Substring(posDelim + 1));

                    c = new Cell(row, col, button, 0);
                    gameBoard.setGameBoardCell(c);
                }
            }
        }

        private void placePiece(object sender, EventArgs e)
        {
            //place a piece
            if (gameBoard.isPlayerTurn())
            {
                string btnName;
                int col;
                btnName = ((Button)sender).Name;
                btnName = btnName.Substring(btnName.Length - 1);
                col = Int32.Parse(btnName) - 1;
                gameBoard.placePiece(col);
                //check for win
                if (checkWin(gameBoard.getCurCell().getRow(), gameBoard.getCurCell().getCol()))
                {
                    //if it's player vs AI save info
                    if (mode == 1)
                    {
                        saver.updateFile(1, depth);
                    }
                    displayWinState(true, 1);
                }
                else if (!checkWin(gameBoard.getCurCell().getRow(), gameBoard.getCurCell().getCol()))
                {
                    displayTieState();
                }
                //if it's player vs AI, run the AI
                if (mode == 1)
                {
                    //set the depth
                    int column;
                    depthSet = true;
                    if (Depth_box.Text != "")
                    {
                        depth = Int32.Parse(Depth_box.Text);
                        if (depth <= 0)
                        {
                            depth = 7;
                        }
                    }
                    else
                    {
                        depth = 7;
                    }
                    //store column to play
                    column = stacy.initialBoard(gameBoard, depth);
                    //place the piece
                    gameBoard.placePiece(column);
                    //check for wins/ties
                    if (checkWin(gameBoard.getCurCell().getRow(), gameBoard.getCurCell().getCol()))
                    {
                        saver.updateFile(2, depth);
                        displayWinState(true, 2);
                    }
                    else if (!checkWin(gameBoard.getCurCell().getRow(), gameBoard.getCurCell().getCol()))
                    {
                        displayTieState();
                    }
                    //display board evaluations done by the AI
                    string numsofboards = String.Format($"{stacy.getIter():n0}");
                    Iterations_Lbl.Text = ("Boards evaluated by AI: " + numsofboards);
                    stacy.setIter(0);
                    //clear "depth setter"
                    if (depthSet)
                    {
                        Depth_box.Visible = false;
                        WarningRtb.Visible = false;
                        Depth_Lbl.Visible = false;
                        Depth_box.Visible = false;
                    }
                    else
                    {
                        Depth_box.Visible = true;
                        WarningRtb.Visible = true;
                        Depth_Lbl.Visible = true;
                        Depth_box.Visible = true;
                    }
                }
            }
            else if (gameBoard.isPlayerTwoTurn() && mode == 2)
            {
                //logic for player 2 in PVP
                string btnName;
                int col;
                btnName = ((Button)sender).Name;
                btnName = btnName.Substring(btnName.Length - 1);
                col = Int32.Parse(btnName) - 1;
                gameBoard.placePiece(col);
                if (checkWin(gameBoard.getCurCell().getRow(), gameBoard.getCurCell().getCol()))
                {
                    displayWinState(true, 2);
                }
                else if (!checkWin(gameBoard.getCurCell().getRow(), gameBoard.getCurCell().getCol()))
                {
                    displayTieState();
                }
            }

        }

        private void setPreview(object sender, EventArgs e)
        {
            //preview the piece
            if (gameBoard.isPlayerTurn())
            {
                string btnName;
                int col;
                btnName = ((Button)sender).Name;
                btnName = btnName.Substring(btnName.Length - 1);
                col = Int32.Parse(btnName) - 1;
                gameBoard.preview(col);
            }
            else if (gameBoard.isPlayerTwoTurn())
            {
                string btnName;
                int col;
                btnName = ((Button)sender).Name;
                btnName = btnName.Substring(btnName.Length - 1);
                col = Int32.Parse(btnName) - 1;
                gameBoard.preview(col);
            }
        }

        private void clearPreview(object sender, EventArgs e)
        {
            //clear the preview
            gameBoard.clearPreview();
        }

        private void Column5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public int getMode()
        { return mode; }

        private void btn_showPrevGame_Click(object sender, EventArgs e)
        {
            if (form1.getPrevGame() != null)
            {
                form1.getPrevGame().Show();
            }
        }

        private void btn_PlayAgain_Click(object sender, EventArgs e)
        {
            depth = 0;
            form1.setPrevGame(this);
            this.Hide();
            form1.Show();
        }

        public void displayWinState(bool b, int player)
        {
            
            if (b == true)
            {
                if (player == 1)
                {
                    statsForm sf = new statsForm(1);
                    lbl_winText.Text = "Player 1 wins!";
                    lbl_winText.Visible = true;
                    gameBoard.setPlayerTurn(false);
                    gameBoard.setPlayerTwoTurn(false);
                    sf.Show();
                    this.Hide();
                }
                else if (player == 2)
                {
                    if (mode == 1)
                    {
                        statsForm sf = new statsForm(2);
                        lbl_winText.Text = "AI wins";
                        lbl_winText.Visible = true;
                        gameBoard.setPlayerTurn(false);
                        gameBoard.setPlayerTwoTurn(false);
                        sf.Show();
                        this.Hide();
                    }
                    else
                    {
                        statsForm sf = new statsForm(3);
                        lbl_winText.Text = "Player 2 wins!";
                        lbl_winText.Visible = true;
                        gameBoard.setPlayerTurn(false);
                        gameBoard.setPlayerTwoTurn(false);
                        sf.Show();
                        this.Hide();
                    }
                    
                    this.Hide();
                }
            }
            //add something here for the robot as well
        }

        public void displayTieState()
        {
            if (checkFilled())
            {
                statsForm sf = new statsForm(4);
                lbl_winText.Text = "Tie!";
                lbl_winText.Visible = true;
                gameBoard.setPlayerTurn(false);
                gameBoard.setPlayerTwoTurn(false);
                sf.Show();
                this.Hide();
            }
        }

        public bool checkFilled()
        {
            Color playerColor = Color.Red;
            Color libbyColor = Color.Yellow;
            int filledCells = 0;
            const int rows = 6;
            const int cols = 7;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (gameBoard.getGameBoard()[row, col].getButton().BackColor == playerColor ||
                        gameBoard.getGameBoard()[row, col].getButton().BackColor == libbyColor)
                    {
                        filledCells++;
                    }
                }
            }

            if (filledCells==42)
            {
                return true;
            }
            else
            {
                return false;
            }
            //Color playerColor = Color.Red;
            //Color libbyColor = Color.Yellow;
            //int col;
            //int filledCells = 0;
            //for (int row = 0; row < 6; row++)
            //{
            //    for (col=0; col < 7; col++)
            //    {
            //        if (gameBoard.getGameBoard()[row, col].getButton().BackColor == playerColor || gameBoard.getGameBoard()[row, col].getButton().BackColor == libbyColor)
            //        {
            //            filledCells++;
            //            col++;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    if (col==7)
            //    {
            //        col = 0;
            //        row++;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //if (filledCells == 42)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }


        public bool checkWin(int row, int col)
        {
            int diagrightcount = 1;
            int diagleftcount = 1;
            int horcount = 1;
            Color playerColor = Color.Red;
            Color libbyColor = Color.Yellow;
            if (!gameBoard.isPlayerTurn())
            {
                
                //vert
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && gameBoard.getGameBoard()[row - i, col].getButton().BackColor == playerColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                //left
                for (int i = 1; i < 4; i++)
                {
                    if (col - i >= 0 && gameBoard.getGameBoard()[row, col - i].getButton().BackColor == playerColor)
                    {
                        horcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                //right
                for (int i = 1; i < 4; i++)
                {
                    if (col + i < 7 && gameBoard.getGameBoard()[row, col + i].getButton().BackColor == playerColor)
                    {
                        horcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (horcount >= 4)
                {
                    Debug.WriteLine("Read Test Successful");
                    return true;
                }
                
                //diag up right
                for (int i = 1; i < 4; i++)
                {
                    if (row + i < 6 && col + i < 7 && gameBoard.getGameBoard()[row + i, col + i].getButton().BackColor == playerColor)
                    {
                        diagrightcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                //diag down left
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && col - i >= 0 && gameBoard.getGameBoard()[row - i, col - i].getButton().BackColor == playerColor)
                    {
                        diagrightcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (diagrightcount >= 4)
                {
                    Debug.WriteLine("Read Test Successful");
                    return true;
                }
                //diag up left
                for (int i = 1; i < 4; i++)
                {
                    if (row + i < 6 && col - i >= 0 && gameBoard.getGameBoard()[row + i, col - i].getButton().BackColor == playerColor)
                    {
                        diagleftcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                //diag down right
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && col + i < 7 && gameBoard.getGameBoard()[row - i, col + i].getButton().BackColor == playerColor)
                    {
                        diagleftcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (diagleftcount >= 4)
                {
                    Debug.WriteLine("Read Test Successful");
                    return true;
                }
                
                return false;
            }
            else if (!gameBoard.isPlayerTwoTurn() || mode==1)
            {
                //vert
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && gameBoard.getGameBoard()[row - i, col].getButton().BackColor == libbyColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                //left
                for (int i = 1; i < 4; i++)
                {
                    if (col - i >= 0 && gameBoard.getGameBoard()[row, col - i].getButton().BackColor == libbyColor)
                    {
                        horcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                //right
                for (int i = 1; i < 4; i++)
                {
                    if (col + i < 7 && gameBoard.getGameBoard()[row, col + i].getButton().BackColor == libbyColor)
                    {
                        horcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (horcount >= 4)
                {
                    Debug.WriteLine("Read Test Successful");
                    return true;
                }

                //diag up right
                for (int i = 1; i < 4; i++)
                {
                    if (row + i < 6 && col + i < 7 && gameBoard.getGameBoard()[row + i, col + i].getButton().BackColor == libbyColor)
                    {
                        diagrightcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                //diag down left
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && col - i >= 0 && gameBoard.getGameBoard()[row - i, col - i].getButton().BackColor == libbyColor)
                    {
                        diagrightcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (diagrightcount >= 4)
                {
                    Debug.WriteLine("Read Test Successful");
                    return true;
                }
                //diag up left
                for (int i = 1; i < 4; i++)
                {
                    if (row + i < 6 && col - i >= 0 && gameBoard.getGameBoard()[row + i, col - i].getButton().BackColor == libbyColor)
                    {
                        diagleftcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                //diag down right
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && col + i < 7 && gameBoard.getGameBoard()[row - i, col + i].getButton().BackColor == libbyColor)
                    {
                        diagleftcount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (diagleftcount >= 4)
                {
                    Debug.WriteLine("Read Test Successful");
                    return true;
                }

                return false;
            }
            else { return false; }
            //gotta add one for the robot
        }

        private void WarningRtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainGame_Load(object sender, EventArgs e)
        {

        }

        private void MainGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }

}
