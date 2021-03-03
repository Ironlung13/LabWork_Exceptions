using System;

namespace LabWork_Exceptions
{
    public class Matrix
    {
        private double[,] _matrix;
        public (uint x, uint y) Size { get => ((uint)_matrix.GetLength(0), (uint)_matrix.GetLength(1)); }
        public double this[uint x, uint y]
        {
            get => GetValue(x, y);
            set => SetValue(x, y, value);
        }
        private Matrix() { }
        public Matrix(uint size_X, uint size_y, double value)
        {
            _matrix = new double[size_X, size_y];
            for (uint x = 0; x < size_X; x++)
                for (uint y = 0; y < size_y; y++)
                    _matrix[x, y] = value;
        }
        public Matrix(uint size_X, uint size_y) : this(size_X, size_y, 1) { }
        public Matrix(uint size, double value) : this(size, size, value) { }
        public Matrix(uint size) : this(size, 1) { }
        public Matrix((uint x, uint y) size) : this(size.x, size.y) { }
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
        public static Matrix Sum(Matrix a, Matrix b)
        {
            try
            {
                if (a.Size != b.Size)
                {
                    throw new MatrixIncompatibleSizingException(a, b, $"Matrix sizes are incompatible!\nFirst Matrix size: {a.Size}\nSecond Matrix size: {b.Size}");
                }

                Matrix resultingMatrix = new Matrix(a.Size);
                for (uint x = 0; x < a.Size.x; x++)
                    for (uint y = 0; y < a.Size.y; y++)
                        resultingMatrix[x, y] = a[x, y] + b[x, y];

                return resultingMatrix;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Tried to reference an unitialized(null) matrix.");
            }
        }
        public static Matrix Multiply(Matrix a, Matrix b)
        {
            try
            {
                var rA = a.Size.x;
                var cA = a.Size.y;
                var rB = b.Size.x;
                var cB = b.Size.y;
                double temp;
                double[,] resultArray = new double[rA, cB];
                if (cA != rB)
                {
                    throw new MatrixIncompatibleSizingException(a, b, $"Matrix sizes are incompatible!\nFirst Matrix size: {a.Size}\nSecond Matrix size: {b.Size}");
                }
                else
                {
                    for (uint i = 0; i < rA; i++)
                    {
                        for (uint j = 0; j < cB; j++)
                        {
                            temp = 0;
                            for (uint k = 0; k < cA; k++)
                            {
                                temp += a[i, k] * b[k, j];
                            }
                            resultArray[i, j] = temp;
                        }
                    }

                    return new Matrix(resultArray);
                }
            }
            catch (ArgumentNullException)
            {
                throw new NullReferenceException("Tried to reference an unitialized(null) matrix.");
            }
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Sum(a, b);
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Multiply(a, b);
        }
        public static Matrix operator -(Matrix a)
        {
            Matrix result = new Matrix(a.Size);
            for (uint x = 0; x < a.Size.x; x++)
                for (uint y = 0; y < a.Size.y; y++)
                    result[x, y] = -a[x, y];

            return result;
        }
        private double GetValue(uint x, uint y)
        {
            try
            {
                return _matrix[x, y];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new MatrixIndexOutOfRangeException(this, $"Tried to access wrong matrix index [{x},{y}]. Matrix size [{Size}]", ex);
            }
        }
        private void SetValue(uint x, uint y, double value)
        {
            try
            {
               _matrix[x, y] = value;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new MatrixIndexOutOfRangeException(this, $"Tried to access wrong matrix index [{x},{y}]. Matrix size [{Size}]", ex);
            }
        }
    }
}
