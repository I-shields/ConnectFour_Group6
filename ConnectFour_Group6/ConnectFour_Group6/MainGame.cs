using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private Libby libby;
        private int mode;
        private Form1 form1;
        public MainGame(int selector, Form1 form)
        {
            InitializeComponent();
            form1 = form;
            if (selector == 1)
            {
                mode = 1;
                gameBoard = new Board(mode);
                libby = new Libby();
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
                EndTurn_Btn.Visible = false;
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

                    c = new Cell(row, col, button);
                    gameBoard.setGameBoardCell(c);
                }
            }
        }

        private void placePiece(object sender, EventArgs e)
        {
            if (gameBoard.isPlayerTurn())
            {
                string btnName;
                int col;
                btnName = ((Button)sender).Name;
                btnName = btnName.Substring(btnName.Length - 1);
                col = Int32.Parse(btnName) - 1;
                gameBoard.placePiece(col);
                displayWinState(checkWin(gameBoard.getCurCell().getRow(), gameBoard.getCurCell().getCol()), 1);
            }
            else if (gameBoard.isPlayerTwoTurn())
            {
                string btnName;
                int col;
                btnName = ((Button)sender).Name;
                btnName = btnName.Substring(btnName.Length - 1);
                col = Int32.Parse(btnName) - 1;
                gameBoard.placePiece(col);
                displayWinState(checkWin(gameBoard.getCurCell().getRow(), gameBoard.getCurCell().getCol()), 2);
            }

        }

        private void setPreview(object sender, EventArgs e)
        {

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
            gameBoard.clearPreview();
        }

        private void Column5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                gameBoard.setPlayerTurn(false);
                libby.startAI(gameBoard);
                gameBoard.setPlayerTurn(true);
            }
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
                    lbl_winText.Text = "Player 1 wins!";
                    lbl_winText.Visible = true;
                    gameBoard.setPlayerTurn(false);
                    gameBoard.setPlayerTwoTurn(false);
                }
                if (player == 2)
                {
                    lbl_winText.Text = "Player 2 wins!";
                    lbl_winText.Visible = true;
                    gameBoard.setPlayerTurn(false);
                    gameBoard.setPlayerTwoTurn(false);
                }
            }
            //add something here for the robot as well
        }


        public bool checkWin(int row, int col)
        {
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
                //right
                for (int i = 1; i < 4; i++)
                {
                    if (col + i < 7 && gameBoard.getGameBoard()[row, col + i].getButton().BackColor == playerColor)
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
                //diag left
                for (int i = 1; i < 4; i++)
                {
                    if (row + i < 6 && col - i >= 0 && gameBoard.getGameBoard()[row + i, col - i].getButton().BackColor == playerColor)
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
                //diag right
                for (int i = 1; i < 4; i++)
                {
                    if (row + i < 6 && col + i < 7 && gameBoard.getGameBoard()[row + i, col + i].getButton().BackColor == playerColor)
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
                //diag down right
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && col + i < 7 && gameBoard.getGameBoard()[row - i, col + i].getButton().BackColor == playerColor)
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
                //diag down left
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && col - i >= 0 && gameBoard.getGameBoard()[row - i, col - i].getButton().BackColor == playerColor)
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
                return false;
            }
            else if (!gameBoard.isPlayerTwoTurn())
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
                //right
                for (int i = 1; i < 4; i++)
                {
                    if (col + i < 7 && gameBoard.getGameBoard()[row, col + i].getButton().BackColor == libbyColor)
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
                //diag left
                for (int i = 1; i < 4; i++)
                {
                    if (row + i < 6 && col - i >= 0 && gameBoard.getGameBoard()[row + i, col - i].getButton().BackColor == libbyColor)
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
                //diag right
                for (int i = 1; i < 4; i++)
                {
                    if (row + i < 6 && col + i < 7 && gameBoard.getGameBoard()[row + i, col + i].getButton().BackColor == libbyColor)
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
                //diag down right
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && col + i < 7 && gameBoard.getGameBoard()[row - i, col + i].getButton().BackColor == libbyColor)
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
                //diag down left
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && col - i >= 0 && gameBoard.getGameBoard()[row - i, col - i].getButton().BackColor == libbyColor)
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
                return false;
            }
            else { return false; }
            //gotta add one for the robot
        }
    }

}
