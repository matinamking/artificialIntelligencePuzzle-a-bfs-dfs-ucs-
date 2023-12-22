using System;

interface Pazel
{
    bool equalArray(int[,] arr1, int[,] arr2);
    void freList(List<Button> t, Panel b);
    void frePazleControler(List<Button> t, Array arr, bool Clr = true);
    void start();
    void locationZero(int[,] arr, int[] location);
    static void Shuffle<T>(Random random, T[,] array);
}
