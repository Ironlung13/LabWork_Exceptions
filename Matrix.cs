using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork_Exceptions
{
    public class Matrix
    {
        private int[,] _matrix;
        public (uint x, uint y) Size { get => ((uint)_matrix.GetLength(0), (uint)_matrix.GetLength(1)); }
        private Matrix() { }
        public Matrix(uint size_X, uint size_y, int value)
        {
            _matrix = new int[size_X, size_y];
            for (uint x = 0; x < size_X; x++)
                for (uint y = 0; y < size_y; y++)
                    _matrix[x, y] = value;
        }
        public Matrix(uint size_X, uint size_y)
            : this(size_X, size_y, 1) { }
        public Matrix(uint size, int value)
            : this(size, size, value) { }

        public Matrix(uint size)
            : this(size, 1) { }

        public Matrix((uint x, uint y) size)
            : this(size.x, size.y) { }

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

        public static Matrix Multiply(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.Size.x != secondMatrix.Size.y && firstMatrix.Size.y != secondMatrix.Size.x)
            {
                throw new ArgumentException("Matrices can't be multiplied.");
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
    }
}
