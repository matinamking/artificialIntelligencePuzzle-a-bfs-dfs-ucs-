using Pazel.createPazle;

namespace Pazel.movePazleMatrix
{
    class BFS : Pazle
    {
        private readonly int[,] initialState;
        private readonly int[,] goalState;
        private readonly List<Button> buttonsPazel;
        private int[] location = new int[2];
        private int[] locationGetNeighbors = new int[2];
        public BFS(int[,] initialState, int[,] goalState, List<Button> buttonsPazel)
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
            int[,] moves = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

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
        public void SolveBFS()
        {
            Queue<Tuple<int[,], int, int>> queue = new Queue<Tuple<int[,], int, int>>();
            HashSet<string> visited = new HashSet<string>();

            locationZero(initialState, location);
            queue.Enqueue(new Tuple<int[,], int, int>(initialState, location[0], location[1]));

            while (queue.Count > 0)
            {
                var currentStateTuple = queue.Dequeue();
                int[,] currentState = currentStateTuple.Item1;
                int x = currentStateTuple.Item2;
                int y = currentStateTuple.Item3;

                frePazleControler(buttonsPazel, currentState);
                MessageBox.Show( visited.Count.ToString());

                if (equalArray(currentState, goalState))
                {
                    MessageBox.Show("پازل حل شد!");
                    MessageBox.Show("وضعیت های بررسی شده :"+visited.Count.ToString());
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
                    if (!visited.Contains(newStateString))
                    {
                        visited.Add(newStateString);
                        queue.Enqueue(new Tuple<int[,], int, int>(newState, newX, newY));
                    }
                }

            }
            MessageBox.Show("پازل قابل حل نیست.");
        }
    }
}
