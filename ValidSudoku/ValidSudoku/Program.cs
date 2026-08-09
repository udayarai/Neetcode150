/*
you are given a 9 x 9 sudoku board. A sudoku board is valid if the following rules are followed

1. Each row must contain the digits 1-9 without duplicates
2. Each column must contain the digits 1-9 without duplicates
3. Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without duplicates.

Return true if the Sudoku board is valid, otherwise return false

constraints: board.length == 9, board[i].length == 9, board[i][j] is a digit 1-8 or '.'

Topics: Array, hash table, matrix

Time complexity:
You should aim for a solution as good or better than O(n^2) time and O(n^2) space, where n is the number of rows in the square grid.
*/


namespace ValidSudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] board = [
                ['1','2','.','.','3','.','.','.','.'],
                ['4','.','.','5','.','.','.','.','.'],
                ['.','9','8','.','.','.','.','.','3'],
                ['5','.','.','.','6','.','.','.','4'],
                ['.','.','.','8','.','3','.','.','5'],
                ['7','.','.','.','2','.','.','.','6'],
                ['.','.','.','.','.','.','2','.','.'],
                ['.','.','.','4','1','9','.','.','8'],
                ['.','.','.','.','8','.','.','7','9']
            ];
            Console.WriteLine(IsValidSudoku(board));
        }

        public static bool IsValidSudoku(char[][] board)
        {
            //columns
            for (int i = 0; i < board.Length; i++)
            {
                HashSet<char> columns = new HashSet<char>();
                for (int j = 0; j < board.Length; j++)
                {
                    char columnElement = board[j][i];
                    if (columns.Contains(columnElement))
                    {
                        return false;
                    }

                    if (columnElement == '.') 
                    {
                        continue;
                    } else if (Char.GetNumericValue(columnElement) > 0 && Char.GetNumericValue(columnElement) < 10)
                    {
                        columns.Add(columnElement);
                    } else
                    {
                        return false;
                    }

                }
            }

            //rows
            
            for (int i = 0; i < board.Length; i++)
            {
                HashSet<char> rows = new HashSet<char>();
                for (int j = 0; j < board.Length; j++)
                {
                    char rowElement = board[i][j];
                    if (rows.Contains(rowElement))
                    {
                        return false;
                    }

                    if (rowElement == '.')
                    {
                        continue;
                    } else if (Char.GetNumericValue(rowElement) > 0 && Char.GetNumericValue(rowElement) < 10) 
                    {
                        rows.Add(rowElement);
                    } else
                    {
                        return false;
                    }
                }
                
            }



            //3x3 subBox
            int noOfSubBox = (board.Length * board.Length) / 9; //9 - 3x3 subboxes
            HashSet<char>[] subBoxArray = new HashSet<char>[noOfSubBox];

            for (int i = 0; i < subBoxArray.Length; i++)
            {
                subBoxArray[i] = new HashSet<char>();
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    char item = board[i][j];
                    int subBoxIndex = i/3 * 3 + j/3;
                    
                    if (subBoxArray[subBoxIndex].Contains(item))
                    {
                        return false;
                    }

                    //add what we have already seen
                    if (item == '.')
                    {
                        continue;
                    }  else if (Char.GetNumericValue(item) > 0 && Char.GetNumericValue(item) < 10)
                    {
                        subBoxArray[subBoxIndex].Add(item);
                    }  else
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
    }
}
