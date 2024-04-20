using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace ConnectFour_Group6
{
    public partial class Form1 : Form
        //required variables
    {   private System.Windows.Forms.Timer timer1;
        private Board board = new Board();

        public Form1()
        {
            InitializeComponent();
            //fill the game board (all empty)
            board.fillBoard(GameBoard, 7, 6);
            //console out put for showing all cells
            board.displayBoard();
            //timer setup for preview, runs the "updateDisplay" function
            //every 100 ms
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 100;
            timer1.Tick += updateDisplay;
            timer1.Start();
        }

        private void updateDisplay(object sender, EventArgs e)
        {
            //gets the mouse position based on the gameboard
            Point gamePos = GameBoard.PointToScreen(Point.Empty);
            int mousePos = Cursor.Position.X - gamePos.X;

            if (GameBoard != null)
            {
                //gets the column that the mouse is in
                int boardWidth = GameBoard.Width / GameBoard.ColumnCount;
                int column = mousePos / boardWidth;

                //if the mouse is within the board do whatever is in this statement
                if (column >= 0 && column < GameBoard.ColumnCount)
                {
                    //clears the display, and then shows a preview
                    //of the piece if the player was to "drop" it
                    //runs every 100ms
                    board.clearPreview(GameBoard);
                    board.previewPiece(GameBoard, column);
                }
            }
        }

        private void GameBoard_MouseHover(object sender, EventArgs e)
        {
        }

        private async void GameBoard_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void GameBoard_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
