using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group6
{
    internal class Cell
    {
        int row;
        int col;
        Button btn;
        int player;

        public Cell()
        {

        }

        public Cell(int r, int c, Button b, int p)
        {
            row = r;
            col = c;
            btn = b;
            player = p;
        }

        //====Getters====
        public int getRow()
        {
            return row;
        }

        public int getCol()
        {
            return col;
        }

        public Button getButton()
        {
            return btn;
        }

        //====Setters====
        public void setRow(int r)
        {
            row = r;
        }

        public void setCol(int c)
        {
            col = c;
        }

        public void setButton(Button b)
        {
            btn = b;
        }

        public void setPlayer(int p)
        {
            player = p;
        }

        public int getPlayer()
        {
            return player;
        }
    }
}
