/*using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int[] location = new int[2];
    static bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < 3 && y >= 0 && y < 3;
    }

    static List<Tuple<int, int>> GetNeighbors(int[,] matrix, int x, int y)
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

    static void DFS(int[,] matrix, int depth)
    {
        int[,] targetState = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        int[,] startState = matrix;

        Console.Clear();
        Console.WriteLine($"Depth: {depth}");

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }

        Thread.Sleep(1000);

        if (ArraysEqual(matrix, targetState))
        {
            Console.WriteLine("پازل حل شد!");
            return;
        }
        locationZero(matrix, location);

        foreach (var neighborTuple in GetNeighbors(matrix, location[0], location[1]))
        {
            int newX = neighborTuple.Item1;
            int newY = neighborTuple.Item2;
            int[,] newState = (int[,])matrix.Clone();
            newState[location[0], location[1]] = matrix[newX, newY];
            newState[newX, newY] = matrix[location[0], location[1]];

            DFS(newState, depth + 1);
        }
    }

    static bool ArraysEqual(int[,] arr1, int[,] arr2)
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
    static void locationZero(int[,] arr, int[] location)
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

    static void Main()
    {
        int[,] puzzleMatrix = {
            { 0, 1, 2 },
            { 4, 5, 3 },
            { 7, 8, 6 }
        };

        DFS(puzzleMatrix, 0);
    }
}
*/
using System;
using System.Collections.Generic;
using System.Threading;

/*class Program
{
    static int[,] targetState = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
    static bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < 3 && y >= 0 && y < 3;
    }

    static List<Tuple<int, int>> GetNeighbors(int[,] matrix, int x, int y)
    {
        var neighbors = new List<Tuple<int, int>>();
        int[,] moves = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } }; // right, down, left, up

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

    static void DFS(int[,] matrix, int x, int y, HashSet<string> visited)
    {
         // ترتیب نهایی پازل

        //Console.Clear(); // پاک کردن محتوای کنسول برای نمایش وضعیت جدید

        // نمایش وضعیت جاری ماتریس
        /*for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }*/

//Thread.Sleep(1000); // تاخیر 1 ثانیه

/* if (ArraysEqual(matrix, targetState))
 {
     Console.WriteLine("پازل حل شد!");
     return;
 }

 foreach (var neighborTuple in GetNeighbors(matrix, x, y))
 {
     int newX = neighborTuple.Item1;
     int newY = neighborTuple.Item2;
     int[,] newState = (int[,])matrix.Clone();
     newState[x, y] = matrix[newX, newY];
     newState[newX, newY] = matrix[x, y];

     string newStateString = ArrayToString(newState);
     if (!visited.Contains(newStateString))
     {
         visited.Add(newStateString);
         DFS(newState, newX, newY, visited);
     }
 }
}*/

/*static bool ArraysEqual(int[,] arr1, int[,] arr2)
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
}*/

/* static string ArrayToString(int[,] arr)
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
*/
/* static void Main()
 {
     // مثال: ماتریس پازل با خانه خالی در لوکیشن (0, 0)
     int[,] puzzleMatrix = {
         { 0, 1, 2 },
         { 4, 5, 3 },
         { 7, 8, 6 }
     };

     HashSet<string> visited = new HashSet<string>();
     DFS(puzzleMatrix, 0, 0, visited);
 }
}*/

class Program
{
    static bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < 3 && y >= 0 && y < 3;
    }

    static List<Tuple<int, int>> GetNeighbors(int[,] matrix, int x, int y)
    {
        var neighbors = new List<Tuple<int, int>>();
        List<Tuple<int, int>> moves = new List<Tuple<int, int>> { Tuple.Create(0, 1), Tuple.Create(1, 0), Tuple.Create(0, -1), Tuple.Create(-1, 0) };

        foreach (var move in moves)
        {
            int newX = x + move.Item1;
            int newY = y + move.Item2;
            if (IsValidMove(newX, newY))
            {
                neighbors.Add(Tuple.Create(newX, newY));
            }
        }

        return neighbors;
    }

    static void BFS(int[,] matrix)
    {
        int[,] targetState = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        int[,] startState = matrix;
        Queue<Tuple<int[,], int, int>> queue = new Queue<Tuple<int[,], int, int>>();
        HashSet<string> visited = new HashSet<string>();

        queue.Enqueue(Tuple.Create(startState, 0, 0));

        while (queue.Count > 0)
        {
            var currentStateTuple = queue.Dequeue();
            int[,] currentState = currentStateTuple.Item1;
            int x = currentStateTuple.Item2;
            int y = currentStateTuple.Item3;

            Console.Clear();

            for (int i = 0; i < currentState.GetLength(0); i++)
            {
                for (int j = 0; j < currentState.GetLength(1); j++)
                {
                    Console.Write($"{currentState[i, j]} ");
                }
                Console.WriteLine();
            }

            //Thread.Sleep(1000);

            if (ArraysEqual(currentState, targetState))
            {
                Console.WriteLine("پازل حل شد!");
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
                    queue.Enqueue(Tuple.Create(newState, newX, newY));
                }
            }
        }

        Console.WriteLine("پازل قابل حل نیست.");
    }

    static bool ArraysEqual(int[,] arr1, int[,] arr2)
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

    static string ArrayToString(int[,] arr)
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

    static void Main()
    {
        int[,] puzzleMatrix = {
            { 0, 1, 2 },
            { 4, 5, 3 },
            { 7, 8, 6 }
        };

        BFS(puzzleMatrix);
    }
}

