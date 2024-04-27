using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group6
{
    internal class Libby
    {
        bool action = false;
        int moves = 1;
        public void startAI(Board b) 
        {
            Debug.WriteLine("Moves: " + moves);
            if (!aiColCheck(b) && !aiRowCheck(b) && !aiDiaCheck(b) && !aiDiaReverseCheck(b))
            {
                Debug.WriteLine("No win moves");
                if(!checkCols(b) && !checkRows(b) && !checkDia(b) && !reverseDia(b))
                {
                    Debug.WriteLine("No blocks");
                    aiBuildStrat(b, moves);
                }
            }
            moves++;

        }

        //can I win?
        //can I stop them from winning?
        //build a row

        public bool checkCols(Board b)
        {
            int col;
            Button btn;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for(int j = 0; j < b.getNumofRows(); j++)
                {
                    btn = b.getCell(j, i).getButton();
                    if (btn.BackColor == b.getPlayerColor())
                    {
                        if(j + 2 < b.getNumofRows())
                        {
                            if(b.getCell(j + 1, i).getButton().BackColor == b.getPlayerColor() &&
                                b.getCell(j + 2, i).getButton().BackColor == b.getPlayerColor())
                            {
                                if(j+3 < b.getNumofRows())
                                {
                                    if (b.getCell(j + 3, i).getButton().BackColor == SystemColors.Control)
                                    {
                                        col = i;
                                        b.placePiece(col);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool checkRows(Board b)
        {
            bool placed = false;
            int col;
            int row;
            Button btn;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    if (b.getCell(j, i).getButton().BackColor == b.getPlayerColor())
                    {
                        if (i + 2 < b.getNumofCols())
                        {
                            if (b.getCell(j, i + 1).getButton().BackColor == b.getPlayerColor() &&
                                b.getCell(j, i + 2).getButton().BackColor == b.getPlayerColor())
                            {
                                if (i + 3 < b.getNumofCols())
                                {
                                    if (b.getCell(j, i + 3).getButton().BackColor == SystemColors.Control)
                                    {
                                        row = b.getLowestRow(i + 3);
                                        if (row == j)
                                        {
                                            col = i + 3;
                                            b.placePiece(col);
                                           placed = true;
                                        }
                                    }
                                }
                            }
                        }

                        if (i - 2 >= 0 && !placed)
                        {
                            if (b.getCell(j, i - 1).getButton().BackColor == b.getPlayerColor() &&
                                b.getCell(j, i - 2).getButton().BackColor == b.getPlayerColor())
                            {
                                if (i - 3 >= 0)
                                {
                                    if (b.getCell(j, i - 3).getButton().BackColor == SystemColors.Control)
                                    {
                                        row = b.getLowestRow(i - 3);
                                        if (row == j)
                                        {
                                            col = i - 3;
                                            b.placePiece(col);
                                           placed = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return placed;
        }

        public bool checkDia(Board b) 
        {
            int col;
            int row;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    if (b.getCell(j, i).getButton().BackColor == b.getPlayerColor())
                    {
                        if (i + 2 < b.getNumofCols() && j + 2 < b.getNumofRows())
                        {
                            if (b.getCell(j + 1, i + 1).getButton().BackColor == b.getPlayerColor() &&
                                b.getCell(j + 2, i + 2).getButton().BackColor == b.getPlayerColor())
                            {
                                if (i + 3 < b.getNumofCols() && j + 3 < b.getNumofRows())
                                {
                                    if (b.getCell(j + 3, i + 3).getButton().BackColor == SystemColors.Control)
                                    {
                                        row = b.getLowestRow(i + 3);
                                        if (row == j + 3)
                                        {
                                            col = i + 3;
                                            b.placePiece(col);
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool reverseDia(Board b)
        {           
            int col;
            int row;
            bool placed = false;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    if (b.getCell(j, i).getButton().BackColor == b.getPlayerColor())
                    {
                        Debug.WriteLine("Found");
                        if (i - 2 > 0 && j + 2 < b.getNumofRows())
                        {
                            if (b.getCell(j + 1, i - 1).getButton().BackColor == b.getPlayerColor() &&
                                b.getCell(j + 2, i - 2).getButton().BackColor == b.getPlayerColor())
                            {
                                Debug.WriteLine("Found part 2");
                                if (i - 3 > 0 && j + 3 < b.getNumofRows())
                                {
                                    Debug.WriteLine("Found part 4");
                                    if (b.getCell(j + 3, i - 3).getButton().BackColor == SystemColors.Control)
                                    {
                                        row = b.getLowestRow(i - 3);
                                        Debug.WriteLine("Row: " + row);
                                        Debug.WriteLine("check: " + (i - 2));
                                        if (row == b.getLowestRow(i - 2))
                                        {
                                            col = i - 3;
                                            b.placePiece(col);
                                            placed = true;
                                            return placed;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return placed;
        }

        public bool aiColCheck(Board b)
        {
            int col;
            Button btn;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    btn = b.getCell(j, i).getButton();
                    if (btn.BackColor == b.getLibbyColor())
                    {
                        if (j + 2 < b.getNumofRows())
                        {
                            if (b.getCell(j + 1, i).getButton().BackColor == b.getLibbyColor() &&
                                b.getCell(j + 2, i).getButton().BackColor == b.getLibbyColor())
                            {
                                if (j + 3 < b.getNumofRows())
                                {
                                    if (b.getCell(j + 3, i).getButton().BackColor == SystemColors.Control)
                                    {
                                        col = i;
                                        b.placePiece(col);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool aiRowCheck(Board b)
        {
            int col;
            int row;
            Button btn;
            bool placed = false;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    if (b.getCell(j, i).getButton().BackColor == b.getLibbyColor())
                    {
                        if (i + 2 < b.getNumofCols())
                        {
                            if (b.getCell(j, i + 1).getButton().BackColor == b.getLibbyColor() &&
                                b.getCell(j, i + 2).getButton().BackColor == b.getLibbyColor())
                            {
                                if (i + 3 < b.getNumofCols())
                                {
                                    if (b.getCell(j, i + 3).getButton().BackColor == SystemColors.Control)
                                    {
                                        row = b.getLowestRow(i + 3);
                                        if (row == j)
                                        {
                                            col = i + 3;
                                            b.placePiece(col);
                                            placed = true;
                                        }
                                    }
                                }
                            }
                        }

                        if (i - 2 > 0 && !placed)
                        {
                            if (b.getCell(j, i - 1).getButton().BackColor == b.getLibbyColor() &&
                                b.getCell(j, i - 2).getButton().BackColor == b.getLibbyColor())
                            {
                                if (i - 3 > 0)
                                {
                                    if (b.getCell(j, i - 3).getButton().BackColor == SystemColors.Control)
                                    {
                                        row = b.getLowestRow(i - 3);
                                        if (row == j)
                                        {
                                            col = i - 3;
                                            b.placePiece(col);
                                            placed = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return placed;
        }

        public bool aiDiaCheck(Board b)
        {
            int col;
            int row;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    if (b.getCell(j, i).getButton().BackColor == b.getLibbyColor())
                    {
                        if (i + 2 < b.getNumofCols() && j + 2 < b.getNumofRows())
                        {
                            if (b.getCell(j + 1, i + 1).getButton().BackColor == b.getLibbyColor() &&
                                b.getCell(j + 2, i + 2).getButton().BackColor == b.getLibbyColor())
                            {
                                if (i + 3 < b.getNumofCols() && j + 3 < b.getNumofRows())
                                {
                                    if (b.getCell(j + 3, i + 3).getButton().BackColor == SystemColors.Control && b.isPlayerTurn())
                                    {
                                        row = b.getLowestRow(i + 3);
                                        if (row == j + 3)
                                        {
                                            col = i + 3;
                                            b.placePiece(col);
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool aiDiaReverseCheck(Board b)
        {
            int col;
            int row;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    if (b.getCell(j, i).getButton().BackColor == b.getLibbyColor())
                    {
                        if (i - 2 > 0 && j - 2 > 0)
                        {
                            if (b.getCell(j - 1, i - 1).getButton().BackColor == b.getLibbyColor() &&
                                b.getCell(j - 2, i - 2).getButton().BackColor == b.getLibbyColor())
                            {
                                if (i - 3 > 0 && j - 3 > 0)
                                {
                                    if (b.getCell(j - 3, i - 3).getButton().BackColor == SystemColors.Control)
                                    {
                                        row = b.getLowestRow(i - 3);
                                        if (row == j - 3)
                                        {
                                            col = i - 3;
                                            b.placePiece(col);
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void aiBuildStrat(Board b, int moves)
        {

        }

        public bool buildCol(Board b)
        {
            
            bool placed = false;

            for(int i = 0; i < b.getNumofCols(); i++)
            {
                for(int j = 0; j < b.getNumofRows(); j++)
                {
                    if(b.getCell(j, i).getButton().BackColor == b.getLibbyColor())
                    {
                        if(j + 1 < b.getNumofRows() && b.getCell(j+1, i).getButton().BackColor == SystemColors.Control)
                        {
                            if(!placed)
                            {
                                Debug.WriteLine("Building column");
                                b.placePiece(i);
                                placed = true;
                            }
                        }
                    }
                }
            }

            return placed;
        }

        public bool buildRight(Board b)
        {
            bool placed = false;

            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    if (b.getCell(j, i).getButton().BackColor == b.getLibbyColor())
                    {
                        if (i + 1 < b.getNumofCols() - 1 && b.getCell(j, i + 1).getButton().BackColor == SystemColors.Control)
                        {
                            if (!placed)
                            {
                                Debug.WriteLine("Building right");
                                b.placePiece(i + 1);
                                placed = true;
                            }
                        }
                    }
                }
            }
            return placed;
        }

        public bool buildLeft(Board b)
        {
            
            bool placed = false;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    if (b.getCell(j, i).getButton().BackColor == b.getLibbyColor())
                    {
                        if (i - 1 > 0 && b.getCell(j, i - 1).getButton().BackColor == SystemColors.Control)
                        {
                            if (!placed)
                            {
                                Debug.WriteLine("Building left from: " + i);
                                b.placePiece(i - 1);
                                placed = true;
                            }
                        }
                    }
                }
            }
            return placed;
        }

        public void placeRandom(Board b)
        {
            bool placed = false;
            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    if(b.getCell(j, i).getButton().BackColor == SystemColors.Control && !placed)
                    {
                        b.placePiece(i);
                        placed = true;
                    }
                }
            }
            placed = false;
        }

    }
}
