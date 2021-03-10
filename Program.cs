using System;

namespace LabWork_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Successful methods
            //Create 2 matrices
            Console.WriteLine("SUCCESSFUL METHODS START");
            Console.WriteLine("_______________________________________________________________________________");
            try
            {
                Matrix a = new Matrix(3, 5);
                Matrix b = new Matrix(3, 5);
                a.FillMatrixRandom();
                b.FillMatrixRandom();
                Console.WriteLine("Matrix a:");
                DisplayMatrix(a);
                Console.WriteLine("Matrix b:");
                DisplayMatrix(b);

                //Change value of one element
                try
                {
                    a[0, 0] = -1000;
                    Console.WriteLine("Successfully changed element at [0,0]");
                    Console.WriteLine("Matrix a:");
                    DisplayMatrix(a);
                }
                catch(MatrixIndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //Sum 2 matrices
                try
                {
                    Matrix c = a + b;
                    Console.WriteLine("Summed matrix:");
                    DisplayMatrix(c);
                }
                catch (MatrixIncompatibleSizingException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (MatrixFailedCreationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Matrix multiplication:");
            //Create and multiply 2 matrices
            try
            {
                Matrix a = new Matrix(4, 2);
                Matrix b = new Matrix(2, 3);
                a.FillMatrixRandom();
                b.FillMatrixRandom();
                Console.WriteLine("Matrix a:");
                DisplayMatrix(a);
                Console.WriteLine("Matrix b:");
                DisplayMatrix(b);
                try
                {
                    Matrix c = Matrix.Multiply(a, b);
                    Console.WriteLine("Multiplied matrices result matrix:");
                    DisplayMatrix(c);
                }
                catch (MatrixIncompatibleSizingException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (MatrixFailedCreationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("_______________________________________________________________________________");
            Console.WriteLine("SUCCESSFUL METHODS END");
            Console.WriteLine();

            ///Unsuccessful methods (custom exceptions included)
            Console.WriteLine("BOTCHED METHODS START");
            Console.WriteLine("_______________________________________________________________________________");
            //Fail to create matrix
            try
            {
                Matrix negativeSize = new Matrix(-3, 5);
                Console.WriteLine("Matrix a:");
                DisplayMatrix(negativeSize);
            }
            catch (MatrixFailedCreationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Create 2 matrices
            try
            {
                Matrix a = new Matrix(4, 4);
                Matrix b = new Matrix(2, 3);
                a.FillMatrixRandom();
                b.FillMatrixRandom();
                Console.WriteLine("Matrix a:");
                DisplayMatrix(a);
                Console.WriteLine("Matrix b:");
                DisplayMatrix(b);

                //Fail to change element
                try
                {
                    a[-3, 3000] = -1000;
                    Console.WriteLine("Successfully changed element at [-3, 3000]");
                    Console.WriteLine("Matrix a:");
                    DisplayMatrix(a);
                }
                catch (MatrixIndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //Fail to sum 2 matrices
                try
                {
                    Matrix c = Matrix.Sum(a, b);
                    Console.WriteLine("Summed matrix:");
                    DisplayMatrix(c);
                }
                catch (MatrixIncompatibleSizingException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //Fail to multiply 2 matrices
                try
                {
                    Matrix c = Matrix.Multiply(a, b);
                    Console.WriteLine("Multiplied matrices result matrix:");
                    DisplayMatrix(c);
                }
                catch (MatrixIncompatibleSizingException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (MatrixFailedCreationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("_______________________________________________________________________________");
            Console.WriteLine("BOTCHED METHODS END");

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
            Console.WriteLine();
        }
    }
}
