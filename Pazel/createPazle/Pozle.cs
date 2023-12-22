using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazel.createPazle
{
    class Pazle
    {
        protected class PuzzleState
        {
            public int[,] Matrix { get; }
            public int Cost { get; }

            public PuzzleState(int[,] matrix, int cost)
            {
                Matrix = matrix;
                Cost = cost;
            }
        }
        protected bool equalArray(int[,] arr1, int[,] arr2)
        {
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    if (arr1[i, j] != arr2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public void freList(List<Button> t, Panel b)
        {
            foreach (Button button in b.Controls)
            {
                t.Add(button);
            }
        }
        public void frePazleControler(List<Button> t, Array arr)
        {
            int counter = 0;
            foreach (var num in arr)
            {
                int i = t.FindIndex(x => x.TabIndex == counter);
                counter++;
                t[i].Text = num.ToString();
            }
        }
        public void frePazleControlerColor(List<Button> t, Array arr)
        {
            int counter = 0;
            foreach (var num in arr)
            {
                int i = t.FindIndex(x => x.TabIndex == counter);
                counter++;
                t[i].Text = num.ToString();
                t[i].BackColor = Color.Green;
            }
        }
        public void locationZero(int[,] arr, int[] location)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        location[0] = i;
                        location[1] = j;
                        break;
                    }
                }
            }
        }
        protected string ArrayToString(int[,] arr)
        {
            string result = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result += arr[i, j].ToString();
                }
            }

            return result;
        }
        protected bool IsValidMove(int x, int y)
        {
            return x >= 0 && x < 3 && y >= 0 && y < 3;
        }

        protected List<PuzzleState> GetNeighbors(PuzzleState currentState)
        {
            List<PuzzleState> neighbors = new List<PuzzleState>();
            int[,] moves = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

            int newX = -1, newY = -1;

            for (int j = 0; j < currentState.Matrix.GetLength(0); j++)
            {
                for (int k = 0; k < currentState.Matrix.GetLength(1); k++)
                {
                    if (currentState.Matrix[j, k] == 0)
                    {
                        newX = j;
                        newY = k;
                        break;
                    }
                }

                if (newX != -1 && newY != -1)
                    break;
            }

            for (int i = 0; i < moves.GetLength(0); i++)
            {
                int movedX = newX + moves[i, 0];
                int movedY = newY + moves[i, 1];

                if (IsValidMove(movedX, movedY))
                {
                    int[,] newMatrix = (int[,])currentState.Matrix.Clone();
                    newMatrix[newX, newY] = currentState.Matrix[movedX, movedY];
                    newMatrix[movedX, movedY] = 0;

                    PuzzleState neighbor = new PuzzleState(newMatrix, currentState.Cost + 1);
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }
    }
}
