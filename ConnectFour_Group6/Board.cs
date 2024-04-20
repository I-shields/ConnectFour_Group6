using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group6
{
    internal class Board
    {
        //A list to keep track of all cells
        private List<Cell> boardList = new List<Cell>();

        //Fill the list with objects of type Cell
        //need to pass gameBoard (gb) so it can add panels, also
        //needs two ints, one for number of columns (c) and one
        //for number of rows (r)
        public void fillBoard(TableLayoutPanel gb, int c, int r)
        {
            //nested for loop to fill each column and row
            //with a Cell and a Panel
            for (int i = 0; i <= c; i++)
            {
                for (int j = 0; j <= r; j++)
                {
                    Cell cell = new Cell();
                    cell.fillBoard(i, j);
                    boardList.Add(cell);
                    addPanels(gb, i, j);
                }
            }
        }

        //adds a Panel so we can change the color of each cell
        public void addPanels(TableLayoutPanel gb, int c, int r)
        {
            Panel p = new Panel();
            p.Dock = DockStyle.Fill;
            gb.Controls.Add(p, c, r);
        }

        public void displayBoard()
        {
            //loops through the list and displays the playerID, Column, and the row
            for (int i = 0; i < boardList.Count(); i++)
            {
                Debug.WriteLine("Player ID: " + boardList[i].getPlayerID());
                Debug.WriteLine("Column pos: " + boardList[i].getColumnPos());
                Debug.WriteLine("Row pos: " + boardList[i].getRowPos());
            }
        }

        //this function is for displaying a preview of where
        //the players piece would go if they "dropped" it
        public void previewPiece(TableLayoutPanel gb, int c)
        {
            //create a Control variable
            Control con;
            //get the lowest row == NEEDS WORK == the returned number is one off
            int lr = getLowestRow(c) - 1;
            
            //loops through the list  == I THINK WE CAN DELETE ALL THIS AND JUST KEEP LINES 72 AND 73 ==
            for (int i = 0; i < boardList.Count(); i++)
            {
                //if a valid position is found, enter the if statement
                if (boardList[i].getColumnPos() == c && boardList[i].getRowPos() == lr)
                {
                    //get the controller from the position (Panel)
                    con = gb.GetControlFromPosition(c, lr);
                    //change the color of the panel to red
                    con.BackColor = Color.Red;
                }
            }
        }

        //goes through and clears the panel
        //== NEED TO ADD A CATCH SO IT DOES NOT OVERWRITE EXSITING PIECES ==
        public void clearPreview(TableLayoutPanel gb)
        {
            Control cont;
            int c;
            int r;
            for(int i = 0; i < boardList.Count();i++)
            {
                c = boardList[i].getColumnPos();
                r = boardList[i].getRowPos();
                cont = gb.GetControlFromPosition(c, r);
                //if no controller is returned, skip this statement
                if(cont != null)
                {
                    cont.BackColor = Color.White;
                }
            }
        }

        //HAVEN'T TESTED!!!
        //this is supposed to change the cell from blank to piece
        public void addPiece(int c, int r, int p)
        {
            int bottomRow;
            if (checkLocation(c, r))
            {
                //returned number is most likely off
                bottomRow = getLowestRow(c);

                for (int i = 0; i < boardList.Count(); i++) 
                {
                    if (boardList[i].getColumnPos() == c && boardList[i].getRowPos() == r)
                    {
                        boardList[i].changeCell(p, c, r);
                    }
                }
            }


        }

        //HAVEN'T TESTED YET!!
        public bool checkLocation(int c, int r)
        {
            //checks to see if spot is opened
            foreach (Cell cell in boardList)
            {
                //needs completely rewrote, 
                if (cell.getColumnPos() == c && cell.getRowPos() == r)
                {
                    return false;
                }
            }
            return true;
        }

        //the trouble code, return number is one off
        public int getLowestRow(int c)
        {
            int lowestRow = 0;

            for (int i = 0; i < boardList.Count(); i++)
            {
                //makes sure it's in the right column, not an existing player piece, and greater then the current lowest
                if (boardList[i].getColumnPos() == c && boardList[i].getPlayerID() == 0 && boardList[i].getRowPos() > lowestRow)
                {
                    lowestRow = boardList[i].getRowPos();
                }
            }
            return lowestRow;
        }

    }
}
