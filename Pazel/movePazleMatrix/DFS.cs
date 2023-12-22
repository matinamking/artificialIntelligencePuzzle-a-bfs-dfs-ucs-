using Pazel.createPazle;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pazel.movePazleMatrix
{
    class DFS : Pazle
    {
        private readonly int[,] initialState;
        private readonly int[,] goalState;
        private readonly List<Button> buttonsPazel;
        private List<int[,]> path;

        public DFS(int[,] initialState, int[,] goalState, List<Button> buttonsPazel)
        {
            this.initialState = initialState;
            this.goalState = goalState;
            this.path = new List<int[,]>();
            this.buttonsPazel = buttonsPazel;
        }

        public void SolveDFS()
        {
            PuzzleState initialPuzzleState = new PuzzleState(initialState, 0);

            Stack<PuzzleState> stack = new Stack<PuzzleState>();
            HashSet<string> visited = new HashSet<string>();

            stack.Push(initialPuzzleState);

            while (stack.Count > 0)
            {
                PuzzleState currentState = stack.Pop();

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
                        stack.Push(neighbor);
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
