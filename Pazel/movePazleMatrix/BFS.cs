using Pazel.createPazle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazel.movePazleMatrix
{
    class BFS : Pazle
    {
        private readonly int[,] initialState;
        private readonly int[,] goalState;
        private readonly List<Button> buttonsPazel;
        private List<int[,]> path;

        public BFS(int[,] initialState, int[,] goalState, List<Button> buttonsPazel)
        {
            this.initialState = initialState;
            this.goalState = goalState;
            this.path = new List<int[,]>();
            this.buttonsPazel = buttonsPazel;
        }

        public void SolveBFS()
        {
            PuzzleState initialPuzzleState = new PuzzleState(initialState, 0);

            Queue<PuzzleState> queue = new Queue<PuzzleState>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue(initialPuzzleState);

            while (queue.Count > 0)
            {
                PuzzleState currentState = queue.Dequeue();

                path.Add(currentState.Matrix);

                if (IsGoalState(currentState.Matrix))
                {
                    MessageBox.Show("پازل حل شد با" + path.Count + "حرکت!");
                    frePazleControler(buttonsPazel, currentState.Matrix);
                    return;
                }

                string currentStateString = ArrayToString(currentState.Matrix);

                if (!visited.Contains(currentStateString))
                {
                    visited.Add(currentStateString);

                    List<PuzzleState> neighbors = GetNeighbors(currentState);

                    foreach (PuzzleState neighbor in neighbors)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            MessageBox.Show("پازل قابل حل نیست.");
        }

        private bool IsGoalState(int[,] matrix)
        {
            return equalArray(matrix, goalState);
        }
    }
}
