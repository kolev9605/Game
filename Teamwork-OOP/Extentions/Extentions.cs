using System;

namespace Teamwork_OOP.Extentions
{
    public static class Extentions
    {
        public static void ForEach<T>(this T[,] array, Action<T> action)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    action(array[i, k]);
                }
            }
        }
    }
}