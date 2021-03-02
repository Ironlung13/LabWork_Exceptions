using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork_Exceptions
{
    public class Matrix
    {
        private int[,] _matrix;
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

        public Matrix GetEmpty(uint size_X, uint size_Y)
        {
            return new Matrix(size_X, size_Y, 0);
        }
        public Matrix GetEmpty(uint size)
        {
            return GetEmpty(size, 0);
        }
    }
}
