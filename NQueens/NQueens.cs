using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NQueens
{
    public class NQueens
    {
        public List<List<int>> board = new List<List<int>>();
        public Dictionary<String,String> solutionsDictionary = new Dictionary<String, String>();

        public int noOfQueens;
        public int steps = 0;

        public NQueens(int n)
        {
            noOfQueens = n;
            SolveProblem(n);
        }
        
        public void SolveProblem(int n)
        {
            //Create board
            for (int i = 0; i < n; i++)  
            {  
                List<int> row = Enumerable.Repeat(0, n).ToList();  
                board.Add(row);  
            }  
            //start placing queen  
            PlaceQueen();  
            Console.WriteLine("Total Solutions: " + solutionsDictionary.Count);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var list in solutionsDictionary)
            {
                stringBuilder.AppendLine("Solution: found in " + list.Value + " steps.");
                foreach (var val in list.Key)
                {                
                    
                    stringBuilder.Append(val);
                }

                stringBuilder.AppendLine();
            }

            Console.WriteLine(stringBuilder.ToString());
        }
        public  void PlaceQueen(int nQueen = 0)
        {
            if (noOfQueens <= nQueen)
            {
                return;
            }

            for (int i = 0; i < noOfQueens; i++)  
            {  

                steps++;
                
                if (board[nQueen][i] != 0)
                {
                    continue;
                }
                
                board[nQueen][i] = -1;  
                UpdateBoard(nQueen, i, 1);  
  
                if (nQueen == noOfQueens - 1)
                {
                    AddBoardToSolutions();
                }
                else
                {
                    PlaceQueen(nQueen + 1);

                }
                
                board[nQueen][i] = 0;  
                UpdateBoard(nQueen, i, -1);  

            }
        }
        
        public  void UpdateBoard(int i,  int j,  int value)  
        {  

            for (int k = 0; k < i; k++)  
                board[k][j] += value;   
  
            //for down  
            for (int k = i + 1; k < noOfQueens; k++)  
                board[k][j] += value;   
  
            //for left  
            for (int k = 0; k < j; k++)  
                board[i][k] += value;

            //for up-left  
            for (int m = i - 1, n = j - 1; m >= 0 && n >= 0; m--, n--)  
                board[m][n] += value;

            //for down-left  
            for (int m = i + 1, n = j - 1; m < noOfQueens && n >= 0; m++, n--)  
                board[m][n] += value;
            
            //for Right  
            for (int k = j + 1; k < noOfQueens; k++)  
                board[i][k] += value;

            //for up-right  
            for (int m = i - 1, n = j + 1; m >= 0 && n < noOfQueens; m--, n++)  
                board[m][n] += value;
            
            //for down-right  
            for (int m = i + 1, n = j + 1; m < noOfQueens && n < noOfQueens; m++, n++)  
                board[m][n] += value;   
            
        }  
        
        public void AddBoardToSolutions()  
        {  
            string result = String.Empty;
            for (int k = 0; k < noOfQueens; k++)  
            {  
                string row = string.Empty;  
                for (int j = 0; j < noOfQueens; j++)  
                    row += board[k][j] == -1 ? "Q" : "-";  
                result += row + Environment.NewLine;
            }

            solutionsDictionary.Add(result, steps.ToString());
            //reset the steps
            steps = 0;
        }  
    }
}