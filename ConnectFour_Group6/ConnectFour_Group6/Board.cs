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
        private bool playerTurn = true;
        private bool playerTwoTurn = false;
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

        public Color getPlayerColor()
        {
            return playerColor;
        }

        public Color getLibbyColor()
        {
            return libbyColor;
        }

        public bool isPlayerTurn()
        {
            return playerTurn;
        }
        public int getLowestRow(int c)
        {
            Cell cell;
            Button button;
            int row = 0;
            bool lowestFound = false;

            while (!lowestFound && row < numOfRows - 1)
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

        public bool checkPos(int r, int c)
        {
            if (gameBoard[r, c].getButton().BackColor != playerColor && gameBoard[r, c].getButton().BackColor != libbyColor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void preview(int c)
        {
            int lr = getLowestRow(c);
            if (playerTurn && gameBoard[lr, c].getButton().BackColor != playerColor && gameBoard[lr, c].getButton().BackColor != libbyColor)
            {
                gameBoard[lr, c].getButton().BackColor = playerPreview;
            }
            else if (!playerTurn && gameBoard[lr, c].getButton().BackColor != playerColor && gameBoard[lr, c].getButton().BackColor != libbyColor)
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
            Debug.WriteLine("Lowest row is: " + lr);
            if (playerTurn && checkPos(lr, c))
            {
                Cell Placeholder = gameBoard[lr, c];
                gameBoard[lr, c].getButton().BackColor = playerColor;
                checkWin(Placeholder.getRow(), Placeholder.getCol());
            }
            else if(!playerTurn && checkPos(lr, c))
            {
                if (playerTwoTurn)
                {
                    Cell Placeholder = gameBoard[lr, c];
                    gameBoard[lr, c].getButton().BackColor = libbyColor;
                    //checkWin(Placeholder.getRow(), Placeholder.getCol());
                }
                else
                {
                    gameBoard[lr, c].getButton().BackColor = libbyColor;
                    //playerTurn = true;
                }
            }
        }


        public void checkWin(int row, int col)
        {
            if (playerTurn)
            {
                //vert
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && gameBoard[row - i, col].getButton().BackColor == playerColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (col - i >= 0 && gameBoard[row, col - i].getButton().BackColor == playerColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (col + i < 7 && gameBoard[row, col + i].getButton().BackColor == playerColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (row + i < 6 && col - i >= 0 && gameBoard[row + i, col - i].getButton().BackColor == playerColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (row + i < 6 && col + i < 7 && gameBoard[row + i, col + i].getButton().BackColor == playerColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (row - i >= 0 && col + i < 7 && gameBoard[row - i, col + i].getButton().BackColor == playerColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (row - i >= 0 && col - i >= 0 && gameBoard[row - i, col - i].getButton().BackColor == playerColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                //vert
                for (int i = 1; i < 4; i++)
                {
                    if (row - i >= 0 && gameBoard[row - i, col].getButton().BackColor == libbyColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (col - i >= 0 && gameBoard[row, col - i].getButton().BackColor == libbyColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (col + i < 7 && gameBoard[row, col + i].getButton().BackColor == libbyColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (row + i < 6 && col - i >= 0 && gameBoard[row + i, col - i].getButton().BackColor == libbyColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (row + i < 6 && col + i < 7 && gameBoard[row + i, col + i].getButton().BackColor == libbyColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (row - i >= 0 && col + i < 7 && gameBoard[row - i, col + i].getButton().BackColor == libbyColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
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
                    if (row - i >= 0 && col - i >= 0 && gameBoard[row - i, col - i].getButton().BackColor == libbyColor)
                    {
                        if (i == 3)
                        {
                            Debug.WriteLine("Read Test Success");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void setPlayerTurn(bool b)
        {
            playerTurn = b;
        }

        public void setPlayerTwoTurn(bool b)
        {
            playerTwoTurn = b;
        }

        public bool isPlayerTwoTurn()
        {
            return playerTwoTurn;
        }
    }

}