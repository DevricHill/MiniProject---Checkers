using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace MiniProject___Checkers.Model
{

    internal class Checkers
    {
        public int RowSize { get; } = 8;
        public int ColumnSize { get; } = 8;
        public char Turn { get; private set; }


        public int[,] JumppedCoords;
        private bool isJumpped;
        public bool IsJumpped { get { return isJumpped; } }
        public Dictionary<string, char> CheckerBoard;

        private char[] _pieces = { 'x', 'X', 'y', 'Y'};

        public Checkers()
        {
            CheckerBoard = new Dictionary<string, char>();
            CreateBoard(RowSize, ColumnSize);
            isJumpped = false;
            Turn = SetRandomTurn();
            JumppedCoords = new int[1,2];
        }

        public void SwitchTurn()
        {
            isJumpped = false;

            if (Turn == _pieces[0]) Turn = _pieces[2];
            else Turn = _pieces[0];
        }

        private char SetRandomTurn()
        {
            Random random = new Random();

            return random.Next(0, 10) <= 5 ? 'x' : 'y';
        }


        public char GetPiece(int index)
        {
            return _pieces[index];
        }

        public void CreateBoard(int row, int column)
        {

            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < column; y++)
                {
                    if ((x + y) % 2 != 0) { CheckerBoard.Add($"{x} {y}", 'W'); }
                    else
                    {
                        if (x < 3) { CheckerBoard.Add($"{x} {y}", _pieces[0]); }
                        else if (x > 4) { CheckerBoard.Add($"{x} {y}", _pieces[2]); }
                        else { CheckerBoard.Add($"{x} {y}", 'B'); }
                    }
                    
                    
                }
            }
        }

        public bool IsInXRange(int row, int col, int newRow, int newCol)
        {
            if (CheckerBoard[$"{newRow} {newCol}"] != 'B')
            {
                return false;
            }

            int rowDifference = newRow - row;
            int colDifference = Math.Abs(col - newCol);

            switch (CheckerBoard[$"{row} {col}"]) 
            {
                case 'x':
                    if (rowDifference == 1 && colDifference == 1) return true;
                    if (rowDifference == 2 && colDifference == 2)
                    {
                        int midRow = (row + newRow) / 2;
                        int midCol = (col + newCol) / 2;
                        char jumpped = CheckerBoard[$"{midRow} {midCol}"];

                        if(jumpped == 'y' || jumpped == 'Y')
                        {
                            JumppedCoords[0, 0] = midRow;
                            JumppedCoords[0, 1] = midCol;

                            CheckerBoard[$"{midRow} {midCol}"] = 'B';

                            isJumpped = true;
                            return true;
                        }
                    }

                    break;
                case 'X':
                    break;
            
            }

            return false;
        }



        public bool IsInYRange(int row, int col, int newRow, int newCol)
        {
            if (CheckerBoard[$"{newRow} {newCol}"] != 'B')
            {
                return false;
            }

            int rowDifference = newRow + row;
            int colDifference = Math.Abs(col - newCol);

            switch (CheckerBoard[$"{row} {col}"])
            {
                case 'y':
                    if (rowDifference == 1 && colDifference == 1) return true;
                    if (rowDifference == 2 && colDifference == 2)
                    {
                        int midRow = (row + newRow) / 2;
                        int midCol = (col + newCol) / 2;
                        char jumpped = CheckerBoard[$"{midRow} {midCol}"];

                        if (jumpped == 'x' || jumpped == 'X')
                        {
                            JumppedCoords[0, 0] = midRow;
                            JumppedCoords[0, 1] = midCol;

                            CheckerBoard[$"{midRow} {midCol}"] = 'B';

                            isJumpped = true;
                            return true;
                        }
                    }

                    break;
                case 'Y':
                    break;

            }

            return false;
        }

        public bool IsInBounds(int currentRow, int currentCol, int newRow, int newCol)
        {
            switch (Turn) 
            {
                case 'x':
                    return IsInXRange(currentRow, currentCol, newRow, newCol);
                case 'y':
                    return IsInYRange(currentRow, currentCol, newRow, newCol);
            }


            return false;
        }

        public bool PlaceChip(int currentRow, int currentCol, int newRow, int newCol)
        {

            

            if (IsInBounds(currentRow, currentCol, newRow, newCol))
            {
                CheckerBoard[$"{newRow} {newCol}"] = CheckerBoard[$"{currentRow} {currentCol}"];
                CheckerBoard[$"{currentRow} {currentCol}"] = 'B';
                return true;
            }

            return false;
        }


    }
}
