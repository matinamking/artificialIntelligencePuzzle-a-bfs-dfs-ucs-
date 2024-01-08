using Pazel.createPazle;
using System.Drawing.Drawing2D;

namespace Pazel.movePazleMatrix
{
    class AStar : Pazle
    {
        private readonly int[,] initialState;
        private readonly int[,] goalState;
        private readonly List<Button> buttonsPazel;
        private int[] location = new int[2];
        public AStar(int[,] initialState, int[,] goalState, List<Button> buttonsPazel)
        {
            this.initialState = initialState;
            this.goalState = goalState;
            this.buttonsPazel = buttonsPazel;
        }
        private bool IsValidMove(int x, int y)
        {
            return x >= 0 && x < 3 && y >= 0 && y < 3;
        }

        private List<Tuple<int, int>> GetNeighbors(int[,] matrix, int x, int y)
        {
            var neighbors = new List<Tuple<int, int>>();
            int[,] moves = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } }; // right, down, left, up

            for (int i = 0; i < moves.GetLength(0); i++)
            {
                int newX = x + moves[i, 0];
                int newY = y + moves[i, 1];
                if (IsValidMove(newX, newY))
                {
                    neighbors.Add(new Tuple<int, int>(newX, newY));
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

        /*private int CalculateHeuristic(int[,] currentState)
        {
            int cost = 0;
            int[,] goalMatrix = goalState;

            for (int i = 0; i < currentState.GetLength(0); i++)
            {
                for (int j = 0; j < currentState.GetLength(1); j++)
                {
                    if (currentState[i, j] != goalMatrix[i, j])
                    {
                        cost++;
                    }
                }
            }

            return cost;
        }*/

        private int CalculateHeuristic(int[,] currentState, int[,] goalState)
        {
            int misplacedCount = 0;
            for (int i = 0; i < currentState.GetLength(0); i++)
            {
                for (int j = 0; j < currentState.GetLength(1); j++)
                {
                    if (currentState[i, j] != goalState[i, j])
                    {
                        misplacedCount++;
                    }
                }
            }

            return misplacedCount;
        }

        public void SolveAStar()
        {
            PriorityQueue<Tuple<int[,], int, int>> priorityQueue = new PriorityQueue<Tuple<int[,], int, int>>();
            HashSet<string> visited = new HashSet<string>();

            int startHeuristic = CalculateHeuristic(initialState,goalState);
            locationZero(initialState, location);
            priorityQueue.Enqueue(new Tuple<int[,], int, int>(initialState, location[0], location[1]),startHeuristic);

            while (priorityQueue.Count > 0)
            {
                var currentStateTuple = priorityQueue.Dequeue();
                int[,] currentState = currentStateTuple.Item1;
                int x = currentStateTuple.Item2;
                int y = currentStateTuple.Item3;


                if (equalArray(currentState, goalState))
                {
                    MessageBox.Show("پازل حل شد!");
                    MessageBox.Show("وضعیت های بررسی شده :" + visited.Count.ToString());
                    frePazleControler(buttonsPazel, currentState);
                    return;
                }

                foreach (var neighborTuple in GetNeighbors(currentState, x, y))
                {
                    int newX = neighborTuple.Item1;
                    int newY = neighborTuple.Item2;
                    int[,] newState = (int[,])currentState.Clone();
                    newState[x, y] = currentState[newX, newY];
                    newState[newX, newY] = currentState[x, y];

                    string newStateString = ArrayToString(newState);
                    int newCost = currentStateTuple.Item2 + 1;
                    int newHeuristic = CalculateHeuristic(newState, goalState);
                    int priority = newCost + newHeuristic;

                    if (!visited.Contains(newStateString))
                    {
                        visited.Add(newStateString);
                        //int newHeuristic = CalculateHeuristic(newState);
                        priorityQueue.Enqueue(new Tuple<int[,], int, int>(newState, newX, newY), priority);
                    }
                }
            }

            Console.WriteLine("پازل قابل حل نیست.");
        }
    }
}

