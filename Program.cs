using System;

namespace LabWork_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(3, 6);
            a.FillMatrixRandom();
            DisplayMatrix(a);
            Console.ReadLine();
        }

        public static void DisplayMatrix(Matrix a)
        {
            for (int x = 0; x < a.Size.x; x++)
            {
                for (int y = 0; y < a.Size.y; y++)
                {
                    Console.Write("{0,6}", a[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
