using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group6
{
    internal class Libby
    {
        bool action = false;
        public void startAI(Board b) 
        {
            checkCols(b);
            checkRows(b);
            checkDia(b);

            if (!action)
            {
                b.placePiece(0);
            }
            else
            {
                action = false;
            }
        }

        //can I win?
        //can I stop them from winning?
        //build a row

        public void checkCols(Board b)
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
                                    if (b.getCell(j+3, i).getButton().BackColor == SystemColors.Control)
                                    {
                                        col = i;
                                        b.placePiece(col);
                                        action = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void checkRows(Board b)
        {
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
                                            action = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void checkDia(Board b) 
        {
            int col;
            int row;
            Button btn;
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
                                            action = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
