using ConnectFour_Group6;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group6
{
    internal class Board
    {
        private const int numOfRows = 6;
        private const int numOfCols = 7;

        Cell[,] gameBoard = new Cell[numOfRows, numOfCols];

        bool gameOver;
        bool playerTurn = true;
        Color playerColor = Color.Red;
        Color playerPreview = Color.FromArgb(50, 255, 0, 0);

        //====AI IS KNOWN AS LIBBY!!====
        Color libbyColor = Color.Yellow;
        Color libbyPreviw = Color.FromArgb(50, 255, 222, 0);

        public int getNumofRows()
        {
            return numOfRows;
        }

        public int getNumofCols()
        {
            return numOfCols;
        }

        public Cell getCell(int r, int c)
        {
            return gameBoard[r, c];
        }

        public Cell[,] getGameBoard()
        {
            return gameBoard;
        }

        public void setGameBoardCell(Cell cell)
        {
            gameBoard[cell.getRow(), cell.getCol()] = cell;
        }

        public int getLowestRow(int c)
        {
            Cell cell;
            Button button;
            int row = 0;
            bool lowestFound = false;

            while (!lowestFound && row < numOfRows)
            {
                cell = gameBoard[row, c];
                button = cell.getButton();
                if (button.BackColor != playerColor && button.BackColor != libbyColor)
                {
                    lowestFound = true;
                }
                else
                {
                    row++;
                }
            }
            return row;
        }

        public void preview(int c)
        {
            int lr = getLowestRow(c);
            if (playerTurn)
            {
                gameBoard[lr, c].getButton().BackColor = playerPreview;
            }
            else
            {
                gameBoard[lr, c].getButton().BackColor = libbyPreviw;
            }
        }

        public void clearPreview()
        {
            foreach (Cell cell in gameBoard)
            {
                if (cell.getButton().BackColor != playerColor && cell.getButton().BackColor != libbyColor)
                {
                    cell.getButton().BackColor = SystemColors.Control;
                }
            }
        }

        public void placePiece(int c)
        {
            int lr = getLowestRow(c);

            if (playerTurn)
            {
                gameBoard[lr, c].getButton().BackColor = playerColor;
                playerTurn = false;
            }
            else
            {
                gameBoard[lr, c].getButton().BackColor = libbyColor;
                playerTurn = true;
            }
        }

    }

}