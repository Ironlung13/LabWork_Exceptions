using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork_Exceptions
{
    public class Matrix
    {
        private double[,] _matrix;
        public (uint x, uint y) Size { get => ((uint)_matrix.GetLength(0), (uint)_matrix.GetLength(1)); }
        private Matrix() { }
        public Matrix(uint size_X, uint size_y, double value)
        {
            _matrix = new double[size_X, size_y];
            for (uint x = 0; x < size_X; x++)
                for (uint y = 0; y < size_y; y++)
                    _matrix[x, y] = value;
        }
        public Matrix(uint size_X, uint size_y)
            : this(size_X, size_y, 1) { }
        public Matrix(uint size, double value)
            : this(size, size, value) { }

        public Matrix(uint size)
            : this(size, 1) { }

        public Matrix((uint x, uint y) size)
            : this(size.x, size.y) { }

        public Matrix(double[,] matrix)
        {
            _matrix = matrix;
        }

        public Matrix GetEmpty(uint size_X, uint size_Y)
        {
            return new Matrix(size_X, size_Y, 0);
        }
        public Matrix GetEmpty(uint size)
        {
            return GetEmpty(size, 0);
        }


        public static Matrix Sum(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.Size != secondMatrix.Size)
            {
                throw new ArgumentException("Matrices are of different size");
            }
            Matrix resultingMatrix = new Matrix(firstMatrix.Size);
            for (int x = 0; x < firstMatrix.Size.x; x++)
                for (int y = 0; y < firstMatrix.Size.y; y++)
                    resultingMatrix._matrix[x, y] = firstMatrix._matrix[x, y] + secondMatrix._matrix[x, y];

            return resultingMatrix;
        }

        public static Matrix Multiply(Matrix A, Matrix B)
        {
            var rA = A.Size.x;
            var cA = A.Size.y;
            var rB = B.Size.x;
            var cB = B.Size.y;
            double temp = 0;
            double[,] resultArray = new double[rA, cB];
            if (cA != rB)
            {
                throw new ArgumentException();
            }
            else
            {
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += A._matrix[i, k] * B._matrix[k, j];
                        }
                        resultArray[i, j] = temp;
                    }
                }

                return new Matrix(resultArray);
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Sum(a, b);
        }

        public static Matrix operator -(Matrix a)
        {
            Matrix result = new Matrix(a.Size);
            for (int x = 0; x < a.Size.x; x++)
                for (int y = 0; y < a.Size.y; y++)
                    result._matrix[x, y] = -a._matrix[x, y];

            return result;
        }

        public double GetValue(uint a, uint b)
        {
            if (a >= Size.x || b > Size.y)
            {
                throw new ArgumentException();
            }
            else
            {
                return _matrix[a, b];
            }
        }
    }
}
