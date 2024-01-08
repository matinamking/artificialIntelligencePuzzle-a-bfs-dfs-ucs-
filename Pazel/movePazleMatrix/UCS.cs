using Pazel.createPazle;

namespace Pazel.movePazleMatrix
{
    class UCS : Pazle
    {
        private readonly int[,] initialState;
        private readonly int[,] goalState;
        private readonly List<Button> buttonsPazel;
        private int[] location = new int[2];
        //public int Cost = 0;
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

        /*private int Cost(int[,] matrix)
        {
            // یک معیار ساده برای هزینه، تعداد عناصر درست قرار گرفته در جای صحیح است
            int cost = 0;
            int[,] goalMatrix = goalState;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != goalMatrix[i, j])
                    {
                        cost++;
                    }
                }
            }

            return cost;
        }*/
        /*public int Cost(int[,] currentState)
        {
            // اینجا می‌توانید هزینه ثابتی را برای هر گره در نظر بگیرید
            return 1;
        }*/

        public void SolveUCS()
        {
            PriorityQueue<Tuple<int[,], int, int>> priorityQueue = new PriorityQueue<Tuple<int[,], int, int>>();
            HashSet<string> visited = new HashSet<string>();

            locationZero(initialState, location);
            priorityQueue.Enqueue(new Tuple<int[,], int, int>(initialState, location[0], location[1]), 0);

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
                    //int newCost = currentStateTuple.Item4 + 1;
                    if (!visited.Contains(newStateString))
                    {
                        visited.Add(newStateString);
                        priorityQueue.Enqueue(new Tuple<int[,], int, int>(newState, newX, newY), 1);
                    }
                }
            }

            MessageBox.Show("پازل قابل حل نیست.");
        }
    }
    public class PriorityQueue<T>
    {
        private readonly List<Tuple<T, int>> elements = new List<Tuple<T, int>>();

        public int Count
        {
            get { return elements.Count; }
        }

        public void Enqueue(T item, int priority)
        {
            elements.Add(Tuple.Create(item, priority));
            elements.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        }

        public T Dequeue()
        {
            elements.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            T item = elements[0].Item1;
            elements.RemoveAt(0);
            return item;
        }
    }
}
