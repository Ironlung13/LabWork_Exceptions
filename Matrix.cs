using System;

namespace LabWork_Exceptions
{
    public class Matrix
    {
        private int[,] _matrix;
        public (int x, int y) Size { get => (_matrix.GetLength(0), _matrix.GetLength(1)); }
        public int this[int x, int y]
        {
            get => GetValue(x, y);
            set => SetValue(x, y, value);
        }
        private Matrix() { }
        public Matrix(int size_X, int size_y, int value)
        {
            _matrix = new int[size_X, size_y];
            for (int x = 0; x < size_X; x++)
                for (int y = 0; y < size_y; y++)
                    _matrix[x, y] = value;
        }
        public Matrix(int size_X, int size_y) : this(size_X, size_y, 1) { }
        public Matrix(int size) : this(size, size, 1) { }
        public Matrix((int x, int y) size) : this(size.x, size.y) { }
        public Matrix(int[,] matrix)
        {
            _matrix = matrix;
        }
        public Matrix GetEmpty(int size_X, int size_Y)
        {
            return new Matrix(size_X, size_Y, 0);
        }
        public Matrix GetEmpty(int size)
        {
            return GetEmpty(size, 0);
        }
        public void FillMatrixRandom()
        {
            Random rand = new Random();
            for (int x = 0; x < Size.x; x++)
                for (int y = 0; y < Size.y; y++)
                    _matrix[x, y] = rand.Next(-999, 1000);
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
                for (int x = 0; x < a.Size.x; x++)
                    for (int y = 0; y < a.Size.y; y++)
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
                int temp;
                int[,] resultArray = new int[rA, cB];
                if (cA != rB)
                {
                    throw new MatrixIncompatibleSizingException(a, b, $"Matrix sizes are incompatible!\nFirst Matrix size: {a.Size}\nSecond Matrix size: {b.Size}");
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
            for (int x = 0; x < a.Size.x; x++)
                for (int y = 0; y < a.Size.y; y++)
                    result[x, y] = -a[x, y];

            return result;
        }
        private int GetValue(int x, int y)
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
        private void SetValue(int x, int y, int value)
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
