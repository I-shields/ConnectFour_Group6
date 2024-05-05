using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group6
{
    internal class Cell
    {
        private int row;
        private int col;
        private Button btn;
        private int player;

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

        public int getPlayer()
        {
            return player;
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

    }
}
