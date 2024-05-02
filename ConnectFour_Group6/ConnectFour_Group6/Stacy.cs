using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group6
{
    internal class Stacy
    {
        //get game board
        //weigh initial board
        //simulate other boards
        //stop branches if worse then original
        //find the best outcome
        //play move

        //====BEST====
        // Win game - 10
        // Unbeatable move - 7

        //====GOOD====
        // Single piece - 1
        // AI 2 in a row - 4
        // AI 3 in a row - 6
        // Block player - 5
        // Block a win - 7

        //=====Bad=====
        // Single piece - (-1)
        // Player 2 in a row - (-4)
        // Player 3 in a row - (-6)
        // Player blocks AI - (-5)
        // Block AI win - (-7)

        //====WORSE====
        // Player Wins - (-10)
        // Player unbeatable move - (-7)

        public int iter = 0;

        public struct colInfo
        {
            public int startRow;
            public int endRow;
        }

        public struct rowInfo
        {
            public int startColumn;
            public int endColumn;
        }

        public struct GameBoardScore
        {
            public int aiScore;
            public int playerScore;
        }

        public struct info
        {
            public int column;
            public int row;
            public int playerScore;
            public int aiScore;
        }

        public struct diaInfo
        {
            public int startColumn;
            public int endColumn;
            public int startRow;
            public int endRow;
        }

        public class searchData
        {
            public int value;
            public int move;
        }


        public int startStacy(Board b)
        {
            int column = 0;
            //column = initialBoard(b);

            return column;
        }

        public int getIter()
        {
            return iter;
        }

        public void setIter(int it)
        {
            iter = it;
        }

        public int initialBoard(Board b, int depth)
        {
            Color aiColor = Color.Yellow;
            Color playerColor = Color.Red;
            Cell[,] boardArray;
            boardArray = new Cell[6, 7];


            for (int i = 0; i < b.getNumofCols(); i++)
            {
                for (int j = 0; j < b.getNumofRows(); j++)
                {
                    Cell c = new Cell();
                    c.setCol(i);
                    c.setRow(j);
                    c.setPlayer(b.getCell(j, i).getPlayer());
                    boardArray[j, i] = c;

                }
            }

            int alpha = int.MinValue;
            int beta = int.MaxValue;
            // the depth is the number passed to the function
            int[] result = backToTheFuture(boardArray, depth, alpha, beta, true);
            int move = result[0];
            return move;
        }

        public int scores(List<rowInfo> list)
        {
            int score = 0;
            int length;
            foreach (rowInfo row in list)
            {

                length = row.endColumn - row.startColumn;
                if (length > 0)
                {
                    score += (length + 1) * 2;
                }
            }
            return score;
        }

        public int scores(List<colInfo> list)
        {
            int score = 0;
            int length;
            foreach (colInfo col in list)
            {
                length = col.endRow - col.startRow;
                if (length > 0)
                {
                    score += (length + 1) * 2;
                }
            }
            return score;
        }

        public int scores(List<diaInfo> list)
        {
            int score = 0;
            int length;
            foreach (diaInfo info in list)
            {

                length = info.endRow - info.startRow;
                if (length > 0)
                {
                    score += (length + 1) * 2;
                }
            }
            return score;
        }

        private int buildNext(Cell[,] b, int depth)
        {
            Cell[,] gameBoard;

            gameBoard = new Cell[6, 7];

            gameBoard = rebuildBoard(b);

            int alpha = int.MinValue;
            int beta = int.MaxValue;
            // the depth is the number passed to the function
            int[] result = backToTheFuture(gameBoard, depth, alpha, beta, true);
            int move = result[0];
            return move;

        }

        private int[,] buildValues()
        {
            int[,] boardValues = new int[6, 7];
            int[] row = { 5, 10, 15, 20, 15, 10, 5, 4, 8, 13, 18, 13, 8, 4, 3, 6, 11, 16, 11, 6, 3, 2, 4, 9, 14, 9, 4, 2, 1, 2, 7, 12, 7, 2, 1, 1, 1, 5, 10, 5, 1, 1 };
            int i = 0;
            int j = 0;
            int c = 0;

            while (c < row.Length)
            {

                boardValues[j, i] = row[c];
                if (i == 6)
                {
                    i = 0;
                    j++;
                }
                else
                {
                    i++;
                }
                c++;
            }

            return boardValues;
        }

        public List<colInfo> GetCols(Cell[,] b, int player)
        {

            Color aiColor = Color.Yellow;
            Color playerColor = Color.Red;
            List<colInfo> aiColList = new List<colInfo>();
            List<colInfo> playerColList = new List<colInfo>();


            for (int i = 0; i < 7; i++)
            {
                int temp = 0;
                int counter = 1;

                while (temp < 6)
                {
                    if (b[temp, i].getPlayer() == 2)
                    {
                        counter = temp;
                        colInfo col = new colInfo();
                        col.startRow = temp;

                        while (temp < 6 && b[temp, i].getPlayer() == 2)
                        {
                            counter++;
                            temp++;
                        }
                        col.endRow = counter - 1;

                        if (counter > 2)
                        {
                            aiColList.Add(col);
                        }

                        temp = counter;
                    }

                    temp++;
                }

                temp = 0;
                counter = 1;

                while (temp < 6)
                {
                    if (b[temp, i].getPlayer() == 1)
                    {
                        counter = temp;
                        colInfo col = new colInfo();
                        col.startRow = temp;

                        while (temp < 6 && b[temp, i].getPlayer() == 1)
                        {
                            counter++;
                            temp++;
                        }
                        col.endRow = counter - 1;
                        if (counter > 2)
                        {
                            playerColList.Add(col);
                        }
                        temp = counter;
                    }

                    temp++;
                }

            }

            if (player == 1)
            {
                return playerColList;
            }
            else
            {
                return aiColList;
            }
        }

        public List<rowInfo> GetRows(Cell[,] b, int player)
        {
            Color aiColor = Color.Yellow;
            Color playerColor = Color.Red;
            List<rowInfo> aiRowList = new List<rowInfo>();
            List<rowInfo> playerRowList = new List<rowInfo>();

            for (int i = 0; i < 6; i++)
            {
                int temp = 0;
                int counter = 1;

                while (temp < 6)
                {
                    if (b[i, temp].getPlayer() == 2)
                    {
                        counter = temp;
                        rowInfo row = new rowInfo();
                        row.startColumn = temp;

                        while (temp < 7 && b[i, temp].getPlayer() == 2)
                        {
                            counter++;
                            temp++;
                        }
                        row.endColumn = counter - 1;
                        if (counter > 2)
                        {
                            aiRowList.Add(row);
                        }
                        temp = counter;
                    }
                    temp++;
                }

                temp = 0;
                counter = 1;

                while (temp < 7)
                {
                    if (b[i, temp].getPlayer() == 1)
                    {
                        counter = temp;
                        rowInfo row = new rowInfo();
                        row.startColumn = temp;

                        while (temp < 7 && b[i, temp].getPlayer() == 1)
                        {
                            counter++;
                            temp++;
                        }
                        row.endColumn = counter - 1;
                        if (counter > 2)
                        {
                            playerRowList.Add(row);
                        }
                        temp = counter;
                    }
                    temp++;
                }
            }

            if (player == 1)
            {
                return playerRowList;
            }
            else
            {
                return aiRowList;
            }
        }

        public List<diaInfo> getDia(Cell[,] b, int player)
        {
            Color aiColor = Color.Yellow;
            Color playerColor = Color.Red;
            List<diaInfo> aiDiaList = new List<diaInfo>();
            List<diaInfo> playerDiaList = new List<diaInfo>();

            List<diaInfo> reverseAiDia = new List<diaInfo>();
            List<diaInfo> reversePlayerDia = new List<diaInfo>();


            bool inList = false;

            for (int i = 0; i < 6; i++)
            {
                int tempc = 0;
                int tempr = i;
                int counter = 1;
                int sc;
                while (tempc < 7)
                {

                    if (b[tempr, tempc].getPlayer() == 1)
                    {
                        sc = tempc;
                        while (tempr < 6 && tempc < 7 && b[tempr, tempc].getPlayer() == 1)
                        {
                            tempc++;
                            tempr++;
                            counter++;
                        }

                        if (counter > 2)
                        {
                            diaInfo di = new diaInfo();
                            di.startRow = i;
                            di.endRow = tempr - 1;
                            di.startColumn = sc;
                            di.endColumn = tempc - 1;

                            foreach (diaInfo info in playerDiaList)
                            {
                                int diaInList = info.endColumn - info.startColumn;
                                int newDia = di.endColumn - info.startColumn;
                                if (di.startColumn == info.startColumn || di.endColumn == info.endColumn)
                                {
                                    inList = true;
                                }
                            }

                            if (!inList)
                            {
                                playerDiaList.Add(di);
                            }
                            inList = false;
                        }



                        tempc = sc;
                        counter = 1;
                    }
                    counter = 1;
                    tempc++;
                    tempr = i;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                int tempc = 0;
                int tempr = i;
                int counter = 1;
                while (tempc < 7)
                {
                    if (b[tempr, tempc].getPlayer() == 2)
                    {
                        int sc = tempc;
                        while (tempr < 6 && tempc < 7 && b[tempr, tempc].getPlayer() == 2)
                        {
                            tempc++;
                            tempr++;
                            counter++;
                        }

                        if (counter > 2)
                        {
                            diaInfo di = new diaInfo();
                            di.startRow = i;
                            di.endRow = tempr - 1;
                            di.startColumn = sc;
                            di.endColumn = tempc - 1;

                            foreach (diaInfo info in aiDiaList)
                            {
                                if (di.startColumn == info.startColumn || di.endColumn == info.endColumn)
                                {
                                    inList = true;
                                }
                            }

                            if (!inList)
                            {
                                aiDiaList.Add(di);
                            }
                            inList = false;
                        }

                        tempc = sc;
                    }
                    counter = 1;
                    tempc++;
                    tempr = i;
                }
            }

            reverseAiDia = getReverseDia(b, 2);
            reversePlayerDia = getReverseDia(b, 1);

            foreach (diaInfo info in reverseAiDia)
            {
                aiDiaList.Add(info);
            }

            foreach (diaInfo info in reversePlayerDia)
            {
                playerDiaList.Add(info);
            }

            if (player == 1)
            {
                return playerDiaList;
            }
            else
            {
                return aiDiaList;
            }
        }

        public List<diaInfo> getReverseDia(Cell[,] b, int player)
        {
            Color aiColor = Color.Yellow;
            Color playerColor = Color.Red;
            List<diaInfo> reverseAiDia = new List<diaInfo>();
            List<diaInfo> reversePlayerDia = new List<diaInfo>();
            bool inList = false;

            for (int i = 0; i < 6; i++)
            {
                int tempc = 0;
                int tempr = i;
                int counter = 1;
                int sc;
                while (tempc < 7)
                {

                    if (b[tempr, tempc].getPlayer() == 1)
                    {
                        sc = tempc;
                        while (tempr > -1 && tempc < 7 && b[tempr, tempc].getPlayer() == 1)
                        {
                            tempc++;
                            tempr--;
                            counter++;
                        }

                        if (counter > 2)
                        {
                            diaInfo di = new diaInfo();
                            di.startRow = i;
                            di.endRow = tempr + 1;
                            di.startColumn = sc;
                            di.endColumn = tempc - 1;

                            foreach (diaInfo info in reversePlayerDia)
                            {
                                int diaInList = info.endColumn - info.startColumn;
                                int newDia = di.endColumn - info.startColumn;
                                if (di.startColumn == info.startColumn || di.endColumn == info.endColumn)
                                {
                                    inList = true;
                                }
                            }

                            if (!inList)
                            {
                                reversePlayerDia.Add(di);
                            }
                            inList = false;
                        }



                        tempc = sc;
                        counter = 1;
                    }
                    counter = 1;
                    tempc++;
                    tempr = i;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                int tempc = 0;
                int tempr = i;
                int counter = 1;
                while (tempc < 7)
                {
                    if (b[tempr, tempc].getPlayer() == 2)
                    {
                        int sc = tempc;
                        while (tempr > -1 && tempc < 7 && b[tempr, tempc].getPlayer() == 2)
                        {
                            tempc++;
                            tempr--;
                            counter++;
                        }

                        if (counter > 2)
                        {
                            diaInfo di = new diaInfo();
                            di.startRow = i;
                            di.endRow = tempr + 1;
                            di.startColumn = sc;
                            di.endColumn = tempc - 1;

                            foreach (diaInfo info in reverseAiDia)
                            {
                                if (di.startColumn == info.startColumn || di.endColumn == info.endColumn)
                                {
                                    inList = true;
                                }
                            }

                            if (!inList)
                            {
                                reverseAiDia.Add(di);
                            }
                            inList = false;
                        }

                        tempc = sc;
                    }
                    counter = 1;
                    tempc++;
                    tempr = i;
                }
            }


            if (player == 1)
            {
                return reversePlayerDia;
            }
            else
            {
                return reverseAiDia;
            }
        }

        public bool checkWins(Cell[,] b, int p)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (b[j, i].getPlayer() == p)
                    {
                        //check for vertical wins
                        if (i < 7 && j + 3 < 6 &&
                           b[j + 1, i].getPlayer() == p &&
                           b[j + 2, i].getPlayer() == p &&
                           b[j + 3, i].getPlayer() == p)
                        {
                            return true;
                        }
                        //check for horizontal wins
                        else if (i + 3 < 7 && j < 6 &&
                           b[j, i + 1].getPlayer() == p &&
                           b[j, i + 2].getPlayer() == p &&
                           b[j, i + 3].getPlayer() == p)
                        {
                            return true;
                        }
                        //check for diagonal wins
                        else if (i + 3 < 7 && j + 3 < 6 &&
                            b[j + 1, i + 1].getPlayer() == p &&
                            b[j + 2, i + 2].getPlayer() == p &&
                            b[j + 3, i + 3].getPlayer() == p)
                        {
                            return true;
                        }
                        //check for reverse diagonal wins
                        else if (i + 3 < 7 && j - 3 > -1 &&
                           b[j - 1, i + 1].getPlayer() == p &&
                           b[j - 2, i + 2].getPlayer() == p &&
                           b[j - 3, i + 3].getPlayer() == p)
                        {
                            return true;
                        }

                    }
                }
            }

            return false;
        }

        public int getLowest(Cell[,] b, int c)
        {
            for (int i = 0; i < 6; i++)
            {
                if (b[i, c].getPlayer() == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public int[] getScores(Cell[,] b)
        {
            int[] scoreset;
            int[,] boardValues = new int[6, 7];
            boardValues = buildValues();
            Color aiColor = Color.Yellow;
            Color playerColor = Color.Red;
            List<colInfo> aiColList = new List<colInfo>();
            List<colInfo> playerColList = new List<colInfo>();

            List<rowInfo> aiRowList = new List<rowInfo>();
            List<rowInfo> playerRowList = new List<rowInfo>();

            List<diaInfo> aiDiaList = new List<diaInfo>();
            List<diaInfo> playerDiaList = new List<diaInfo>();

            aiColList = GetCols(b, 2);
            playerColList = GetCols(b, 1);

            aiRowList = GetRows(b, 2);
            playerRowList = GetRows(b, 1);

            aiDiaList = getDia(b, 2);
            playerDiaList = getDia(b, 1);

            int playerScore = 0;
            int aiScore = 0;
            playerScore += scores(playerColList) + scores(playerRowList) + scores(playerDiaList);
            aiScore += scores(aiColList) + scores(aiRowList) + scores(aiDiaList);

            foreach (Cell cell in b)
            {
                if (cell.getPlayer() == 2)
                {
                    aiScore += boardValues[cell.getRow(), cell.getCol()];
                }
                if (cell.getPlayer() == 1)
                {
                    playerScore += boardValues[cell.getRow(), cell.getCol()];
                }
            }
            scoreset = new int[2];
            scoreset[0] = playerScore;
            scoreset[1] = aiScore;

            return scoreset;
        }

        public Cell[,] rebuildBoard(Cell[,] b)
        {
            Cell[,] gameBoard;
            gameBoard = new Cell[6, 7];

            foreach (Cell cell in b)
            {
                Cell cel = new Cell();
                cel.setCol(cell.getCol());
                cel.setRow(cell.getRow()); ;
                cel.setPlayer(cell.getPlayer());
                gameBoard[cell.getRow(), cell.getCol()] = cel;
            }

            return gameBoard;
        }

        public int[] backToTheFuture(Cell[,] b, int depth, int alpha, int beta, bool maximizingPlayer)
        {
            int[] infoReturn;
            bool end = isEnd(b);
            if (depth == 0 || end)
            {
                iter++;
                if (end)
                {
                    bool aiWin = checkWins(b, 2);
                    if (aiWin)
                    {
                        infoReturn = new int[2];
                        infoReturn[0] = 0;
                        infoReturn[1] = int.MaxValue;
                        return infoReturn;
                    }
                    if (!aiWin)
                    {
                        infoReturn = new int[2];
                        infoReturn[0] = 0;
                        infoReturn[1] = int.MinValue;
                        return infoReturn;
                    }
                    else
                    {
                        infoReturn = new int[2];
                        infoReturn[0] = 0;
                        infoReturn[1] = int.MinValue;
                        return infoReturn;
                    }
                }
                else
                {
                    if (maximizingPlayer)
                    {
                        infoReturn = new int[2];
                        infoReturn[0] = 0;
                        infoReturn[1] = getScores(b)[0];
                        return infoReturn;
                    }
                    else
                    {
                        infoReturn = new int[2];
                        infoReturn[0] = 0;
                        infoReturn[1] = getScores(b)[1];
                        return infoReturn;
                    }
                }
            }
            else
            {
                Cell[,] gameBoard;
                gameBoard = new Cell[6, 7];
                gameBoard = rebuildBoard(b);
                if (maximizingPlayer)
                {
                    int maxEval = int.MinValue;
                    int newScore;
                    int lr;
                    int bestMove = 0;

                    for (int i = 0; i < 7; i++)
                    {
                        lr = getLowest(gameBoard, i);
                        if (lr != -1)
                        {
                            iter++;
                            gameBoard[lr, i].setPlayer(2);
                            newScore = backToTheFuture(gameBoard, depth - 1, alpha, beta, false)[1];
                            if (newScore > maxEval)
                            {
                                maxEval = newScore;
                                bestMove = i;
                            }
                            alpha = Math.Max(alpha, maxEval);
                            if (alpha >= beta)
                            {
                                break;
                            }
                            gameBoard = rebuildBoard(b);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    infoReturn = new int[2];
                    infoReturn[0] = bestMove;
                    infoReturn[1] = maxEval;
                    return infoReturn;
                }

                else
                {
                    int minEval = int.MaxValue;
                    int bestMove2 = 0;
                    int lr;
                    int newScore2;
                    for (int i = 0; i < 7; i++)
                    {
                        lr = getLowest(gameBoard, i);
                        if (lr != -1)
                        {
                            iter++;
                            gameBoard[lr, i].setPlayer(1);
                            newScore2 = backToTheFuture(gameBoard, depth - 1, alpha, beta, true)[1];
                            if (newScore2 < minEval)
                            {
                                minEval = newScore2;
                                bestMove2 = i;
                            }
                            beta = Math.Min(beta, minEval);
                            if (alpha >= beta)
                            {
                                break;
                            }
                            gameBoard = rebuildBoard(b);
                        }
                        else
                        { 
                            continue; 
                        }
                    }
                    infoReturn = new int[2];
                    infoReturn[0] = bestMove2;
                    infoReturn[1] = minEval;
                    return infoReturn;

                }

            }
        }

        public bool isEnd(Cell[,] b)
        {
            if(checkWins(b,1))
            {
                return true;
            }

            if(checkWins(b,2))
            { 
                return true; 
            }

            foreach (Cell cell in b)
            {
                if (cell.getPlayer() == 0)
                {
                    return false;
                }
            }

            return false;

        }
    }
}
