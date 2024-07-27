using System;
using System.Collections.Generic;
using System.Linq;
/*
public class AStarNode
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Cost { get; set; }
    public int Heuristic { get; set; }
    public int TotalCost => Cost + Heuristic;
    public AStarNode Parent { get; set; }
}

public class AStar
{
    private static int[,] matrix = {
        {1, 0, 1, 2, 3},
        {2, 9, 1, 4, 3},
        {1, 2, 9, 2, 1},
        {3, 1, 3, 9, 4},
        {4, 2, 1, 3, 2}
    };

    public static List<Tuple<int, int>> FindPath(int startX, int startY, int goalX, int goalY)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        AStarNode startNode = new AStarNode { X = startX, Y = startY, Cost = 0, Heuristic = CalculateHeuristic(startX, startY, goalX, goalY) };
        AStarNode goalNode = new AStarNode { X = goalX, Y = goalY };

        HashSet<string> closedSet = new HashSet<string>();
        PriorityQueue<AStarNode> openSet = new PriorityQueue<AStarNode>();

        openSet.Enqueue(startNode, startNode.TotalCost);

        while (openSet.Count > 0)
        {
            AStarNode current = openSet.Dequeue();

            if (current.X == goalX && current.Y == goalY)
            {
                return ReconstructPath(current);
            }

            closedSet.Add($"{current.X},{current.Y}");

            foreach (var neighbor in GetNeighbors(current.X, current.Y, rows, cols))
            {
                if (closedSet.Contains($"{neighbor.X},{neighbor.Y}"))
                {
                    continue;
                }

                int tentativeCost = current.Cost + 1;
                AStarNode neighborNode = openSet.SingleOrDefault(n => n.X == neighbor.X && n.Y == neighbor.Y);

                if (neighborNode == null || tentativeCost < neighborNode.Cost)
                {
                    if (neighborNode == null)
                    {
                        neighborNode = new AStarNode { X = neighbor.X, Y = neighbor.Y };
                        openSet.Enqueue(neighborNode, neighborNode.TotalCost);
                    }

                    neighborNode.Parent = current;
                    neighborNode.Cost = tentativeCost;
                    neighborNode.Heuristic = CalculateHeuristic(neighbor.X, neighbor.Y, goalX, goalY);
                    openSet.Enqueue(neighborNode, neighborNode.TotalCost);
                }
            }
        }

        return new List<Tuple<int, int>>();
    }

    private static List<Tuple<int, int>> ReconstructPath(AStarNode node)
    {
        List<Tuple<int, int>> path = new List<Tuple<int, int>>();
        while (node != null)
        {
            path.Insert(0, new Tuple<int, int>(node.X, node.Y));
            node = node.Parent;
        }
        return path;
    }

    private static int CalculateHeuristic(int x, int y, int goalX, int goalY)
    {
        return Math.Abs(x - goalX) + Math.Abs(y - goalY);
    }

    private static List<Tuple<int, int>> GetNeighbors(int x, int y, int rows, int cols)
    {
        var neighbors = new List<Tuple<int, int>>();
        int[,] moves = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        foreach (var move in moves)
        {
            int newX = x + move[0];
            int newY = y + move[1];

            if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && matrix[newX, newY] != 9)
            {
                neighbors.Add(new Tuple<int, int>(newX, newY));
            }
        }

        return neighbors;
    }
}

public class PriorityQueue<T>
{
    private readonly List<Tuple<T, int>> elements = new List<Tuple<T, int>>();

    public int Count => elements.Count;

    public void Enqueue(T item, int priority)
    {
        elements.Add(Tuple.Create(item, priority));
    }

    public T Dequeue()
    {
        elements.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        T item = elements[0].Item1;
        elements.RemoveAt(0);
        return item;
    }
}

class Program
{
    static void Main()
    {
        int startX = 0;
        int startY = 0;
        int goalX = 4;
        int goalY = 4;

        List<Tuple<int, int>> path = AStar.FindPath(startX, startY, goalX, goalY);

        if (path.Count > 0)
        {
            Console.WriteLine("Path found:");
            foreach (var point in path)
            {
                Console.WriteLine($"({point.Item1}, {point.Item2})");
            }
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }
}
*/
using System;
using System.Collections.Generic;

/*public class TicTacToeState
{
    public char[,] Board { get; set; }
    public int XCount { get; set; }
    public int OCount { get; set; }

    public TicTacToeState(char[,] board)
    {
        Board = board;
        XCount = CountSymbols('X');
        OCount = CountSymbols('O');
    }

    private int CountSymbols(char symbol)
    {
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Board[i, j] == symbol)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public bool IsTerminal()
    {
        return CheckWin('X') || CheckWin('O') || XCount + OCount == 9;
    }

    private bool CheckWin(char symbol)
    {
        for (int i = 0; i < 3; i++)
        {
            if ((Board[i, 0] == symbol && Board[i, 1] == symbol && Board[i, 2] == symbol) ||
                (Board[0, i] == symbol && Board[1, i] == symbol && Board[2, i] == symbol))
            {
                return true;
            }
        }

        if ((Board[0, 0] == symbol && Board[1, 1] == symbol && Board[2, 2] == symbol) ||
            (Board[0, 2] == symbol && Board[1, 1] == symbol && Board[2, 0] == symbol))
        {
            return true;
        }

        return false;
    }
}

public class TicTacToeSolver
{
    private static readonly List<Tuple<int, int>> PossibleMoves = new List<Tuple<int, int>>
    {
        Tuple.Create(0, 0), Tuple.Create(0, 1), Tuple.Create(0, 2),
        Tuple.Create(1, 0), Tuple.Create(1, 1), Tuple.Create(1, 2),
        Tuple.Create(2, 0), Tuple.Create(2, 1), Tuple.Create(2, 2)
    };

    public static void SolveTicTacToe(char[,] initialState)
    {
        var initialNode = new TicTacToeState(initialState);
        var path = AStarSearch(initialNode);

        if (path == null)
        {
            Console.WriteLine("No solution found.");
        }
        else
        {
            Console.WriteLine("Solution found:");
            foreach (var state in path)
            {
                PrintBoard(state.Board);
                Console.WriteLine();
            }
        }
    }

    private static List<TicTacToeState> AStarSearch(TicTacToeState initialState)
    {
        var openSet = new List<TicTacToeState> { initialState };
        var cameFrom = new Dictionary<TicTacToeState, TicTacToeState>();
        var gScore = new Dictionary<TicTacToeState, int>();
        var fScore = new Dictionary<TicTacToeState, int>();

        gScore[initialState] = 0;
        fScore[initialState] = Heuristic(initialState);

        while (openSet.Count > 0)
        {
            var current = GetLowestFScore(openSet, fScore);

            if (current.IsTerminal())
            {
                return ReconstructPath(cameFrom, current);
            }

            openSet.Remove(current);

            foreach (var move in PossibleMoves)
            {
                var neighborBoard = (char[,])current.Board.Clone();
                if (neighborBoard[move.Item1, move.Item2] == '\0')
                {
                    neighborBoard[move.Item1, move.Item2] = 'X'; // Assuming 'X' is the maximizing player
                    var neighbor = new TicTacToeState(neighborBoard);
                    int tentativeGScore = gScore[current] + 1;

                    if (!gScore.ContainsKey(neighbor) || tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = gScore[neighbor] + Heuristic(neighbor);

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }
        }

        return null;
    }

    private static TicTacToeState GetLowestFScore(List<TicTacToeState> openSet, Dictionary<TicTacToeState, int> fScore)
    {
        int minScore = int.MaxValue;
        TicTacToeState minState = null;

        foreach (var state in openSet)
        {
            if (fScore.ContainsKey(state) && fScore[state] < minScore)
            {
                minScore = fScore[state];
                minState = state;
            }
        }

        return minState;
    }

    private static List<TicTacToeState> ReconstructPath(Dictionary<TicTacToeState, TicTacToeState> cameFrom, TicTacToeState current)
    {
        var path = new List<TicTacToeState> { current };
        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            path.Insert(0, current);
        }
        return path;
    }

    private static int Heuristic(TicTacToeState state)
    {
        return state.XCount;
    }

    private static void PrintBoard(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{board[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    public static void Main()
    {
        char[,] initialState =
        {
            { 'X', 'O', '\0' },
            { '\0', 'X', '\0' },
            { 'O', '\0', 'O' }
        };

        SolveTicTacToe(initialState);
    }
}
*/
using System;
using System.Collections.Generic;

/*public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Cost { get; set; }
    public int Heuristic { get; set; }
    public Node Parent { get; set; }

    public Node(int x, int y, int cost, int heuristic, Node parent = null)
    {
        X = x;
        Y = y;
        Cost = cost;
        Heuristic = heuristic;
        Parent = parent;
    }

    public int TotalCost => Cost + Heuristic;
}

public class AStar
{
    private static readonly int[,] Map = {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 1, 0, 1, 0, 1, 0, 1, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 1, 0, 1, 0, 1, 0, 1, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 1, 0, 1, 0, 1, 0, 1, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 1, 0, 1, 0, 1, 0, 1, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private static readonly int[] Start = { 0, 0 };
    private static readonly int[] Goal = { 8, 8 };

    public static void Main()
    {
        List<Node> path = FindPath();
        if (path != null)
        {
            Console.WriteLine("Path found:");
            foreach (var node in path)
            {
                Console.WriteLine($"({node.X}, {node.Y})");
            }
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }

    private static List<Node> FindPath()
    {
        var openSet = new List<Node> { new Node(Start[0], Start[1], 0, CalculateHeuristic(Start[0], Start[1])) };
        var closedSet = new List<Node>();

        while (openSet.Count > 0)
        {
            Node current = GetLowestFScore(openSet);

            if (current.X == Goal[0] && current.Y == Goal[1])
            {
                return ReconstructPath(current);
            }

            openSet.Remove(current);
            closedSet.Add(current);

            foreach (var neighbor in GetNeighbors(current))
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }

                int tentativeGScore = current.Cost + 1;
                if (!openSet.Contains(neighbor) || tentativeGScore < neighbor.Cost)
                {
                    neighbor.Cost = tentativeGScore;
                    neighbor.Parent = current;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }

        return null; // No path found
    }

    private static List<Node> GetNeighbors(Node node)
    {
        var neighbors = new List<Node>();
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int newX = node.X + dx[i];
            int newY = node.Y + dy[i];

            if (IsValidMove(newX, newY))
            {
                neighbors.Add(new Node(newX, newY, 0, CalculateHeuristic(newX, newY), node));
            }
        }

        return neighbors;
    }

    private static bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < Map.GetLength(0) && y >= 0 && y < Map.GetLength(1) && Map[x, y] == 0;
    }

    private static int CalculateHeuristic(int x, int y)
    {
        // A simple heuristic: Manhattan distance to the goal
        return Math.Abs(x - Goal[0]) + Math.Abs(y - Goal[1]);
    }

    private static Node GetLowestFScore(List<Node> openSet)
    {
        int minScore = int.MaxValue;
        Node minNode = null;

        foreach (var node in openSet)
        {
            int totalCost = node.TotalCost;
            if (totalCost < minScore)
            {
                minScore = totalCost;
                minNode = node;
            }
        }

        return minNode;
    }

    private static List<Node> ReconstructPath(Node current)
    {
        var path = new List<Node> { current };
        while (current.Parent != null)
        {
            current = current.Parent;
            path.Insert(0, current);
        }
        return path;
    }
}
*/