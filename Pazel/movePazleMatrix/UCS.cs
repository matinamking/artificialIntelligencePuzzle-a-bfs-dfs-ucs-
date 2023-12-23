using Pazel.createPazle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazel.movePazleMatrix
{
    class UCS :Pazle
    {
        private readonly int[,] initialState;
        private readonly int[,] goalState;
        private readonly List<Button> buttonsPazel;
        private int[] location = new int[2];
        public UCS(int[,] initialState, int[,] goalState, List<Button> buttonsPazel)
        {
            this.initialState = initialState;
            this.goalState = goalState;
            this.buttonsPazel = buttonsPazel;
        }
        
        private bool IsValidMove(int x, int y)
        {
            return x >= 0 && x < 3 && y >= 0 && y < 3;
        }

        private List<int[,]> GetNeighbors(int[,] currentState)
        {
            var neighbors = new List<int[,]>();
            int[,] moves = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

            for (int i = 0; i < moves.GetLength(0); i++)
            {
                int newX = 0, newY = 0;
                
                locationZero(currentState, location);
                int x = location[0], y = location[1];

                newX = x + moves[i, 0];
                newY = y + moves[i, 1];

                if (IsValidMove(newX, newY))
                {
                    int[,] newMatrix = (int[,])currentState.Clone();
                    newMatrix[x, y] = currentState[newX, newY];
                    newMatrix[newX, newY] = currentState[x, y];

                    neighbors.Add(newMatrix);
                }
            }

            return neighbors;
        }

        private string ArrayToString(int[,] arr)
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

        public void SolveUCS()
        {
            // ابتدایی کردن الگوریتم UCS با حالت ابتدایی
            Queue<Tuple<int[,], int>> queue = new Queue<Tuple<int[,], int>>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue(new Tuple<int[,], int>(initialState, 0));
            visited.Add(ArrayToString(initialState));

            while (queue.Count > 0)
            {
                var currentStateTuple = queue.Dequeue();
                int[,] currentState = currentStateTuple.Item1;
                int cost = currentStateTuple.Item2;

                //frePazleControler(buttonsPazel, currentState);
                //MessageBox.Show("هزینه کل: " + cost);
                

                if (equalArray(currentState, goalState))
                {
                    MessageBox.Show("پازل حل شد!");
                    MessageBox.Show("هزینه کل: " + cost);
                    frePazleControler(buttonsPazel, currentState);
                    return;
                }

                foreach (var neighbor in GetNeighbors(currentState))
                {
                    string neighborString = ArrayToString(neighbor);
                    if (!visited.Contains(neighborString))
                    {
                        visited.Add(neighborString);
                        queue.Enqueue(new Tuple<int[,], int>(neighbor, cost + 1));
                    }
                }
            }

            MessageBox.Show("پازل قابل حل نیست.");
        }
    }
}
