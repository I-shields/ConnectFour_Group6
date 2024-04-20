using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group6
{
    internal class Cell
    {
        //Player ID is used to tell what player has a piece in the cell
        //0 for empty cell, 1 for player 1, 2 for player 2 (or AI)
        private int playerID;
        private int columnPos;
        private int rowPos;

        //fill the board, all cells start off empty
        public void fillBoard(int c, int r)
        {
            playerID = 0;
            columnPos = c;
            rowPos = r;
        }
        //used to change cell, might be redundant!!
        public void changeCell(int i, int c, int r)
        {
            playerID = i;
            columnPos = c;
            rowPos = r;
        }
        //getters
        public int getPlayerID()
        {
            return playerID;
        }

        public int getColumnPos()
        {
            return columnPos;
        }

        public int getRowPos()
        {
            return rowPos;
        }
    }
}
