using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            }
            else if (gameBoard.isPlayerTwoTurn())
            {
                string btnName;
                int col;
                btnName = ((Button)sender).Name;
                btnName = btnName.Substring(btnName.Length - 1);
                col = Int32.Parse(btnName) - 1;
                gameBoard.placePiece(col);
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
            if (gameBoard.isPlayerTurn())
            {
                gameBoard.clearPreview();
            }
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
    }
}
