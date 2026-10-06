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
        public bool IsLoop { get; private set; }
        public string HasWon;


        public Dictionary<string, char> CheckerBoard;

        private char[] _pieces = { 'x', 'X', 'y', 'Y'};


        public Checkers()
        {
            CheckerBoard = new Dictionary<string, char>();
            CreateBoard(RowSize, ColumnSize);
            isJumpped = false;
            IsLoop = true;
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

                        if(jumpped == _pieces[2] || jumpped == _pieces[3])
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
                    int positiveRowDifference = Math.Abs(rowDifference);

                    if (positiveRowDifference == 1 && colDifference == 1) return true;
                    if (positiveRowDifference == 2 && colDifference == 2)
                    {
                        int midRow = (row + newRow) / 2;
                        int midCol = (col + newCol) / 2;
                        char jummped = CheckerBoard[$"{midRow} {midCol}"];

                        if(jummped == _pieces[2] ||  jummped == _pieces[3])
                        {
                            JumppedCoords[0, 0] = midRow;
                            JumppedCoords[0, 1] = midCol;

                            CheckerBoard[$"{midRow} {midCol}"] = 'B';

                            isJumpped = true;
                            return true;
                        }
                    }
                    
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

            int rowDifference = newRow - row;
            int colDifference = Math.Abs(col - newCol);

            switch (CheckerBoard[$"{row} {col}"])
            {
                case 'y':
                    if (rowDifference == - 1 && colDifference == 1) return true;
                    if (rowDifference == - 2 && colDifference == 2)
                    {
                        int midRow = (row + newRow) / 2;
                        int midCol = (col + newCol) / 2;
                        char jumpped = CheckerBoard[$"{midRow} {midCol}"];

                        if (jumpped == _pieces[0] || jumpped == _pieces[1])
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
                    int positiveRowDifference = Math.Abs(rowDifference);

                    if (positiveRowDifference == 1 && colDifference == 1) return true;
                    if (positiveRowDifference == 2 && colDifference == 2)
                    {
                        int midRow = (row + newRow) / 2;
                        int midCol = (col + newCol) / 2;
                        char jummped = CheckerBoard[$"{midRow} {midCol}"];

                        if (jummped == _pieces[0] || jummped == _pieces[1])
                        {
                            JumppedCoords[0, 0] = midRow;
                            JumppedCoords[0, 1] = midCol;

                            CheckerBoard[$"{midRow} {midCol}"] = 'B';

                            isJumpped = true;
                            return true;
                        }
                    }

                    break;

            }

            return false;
        }

        private void AtEnd(int row, int col)
        {
            if (Turn == _pieces[2])
            {
                if (row == 0 && CheckerBoard[$"{row} {col}"] == _pieces[2])
                {
                    CheckerBoard[$"{row} {col}"] = _pieces[3];
                }
            }

            if (Turn == _pieces[0])
            {
                if (row == 7 && CheckerBoard[$"{row} {col}"] == _pieces[0])
                {
                    CheckerBoard[$"{row} {col}"] = _pieces[1];
                }
            }
        }

        private bool IsWon()
        {
            if (!CheckerBoard.ContainsValue(_pieces[0]) && !CheckerBoard.ContainsValue(_pieces[1]))
            {
                HasWon = $"Player Red has won!";
                return true;
            }

            if (!CheckerBoard.ContainsValue(_pieces[2]) && !CheckerBoard.ContainsValue(_pieces[3]))
            {
                HasWon = $"Player Black has won!";
                return true;
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
                AtEnd(newRow, newCol);

                if (IsWon() && IsLoop)
                {
                    IsLoop = false;
                }

                return true;
            }

            return false;
        }


    }
}
