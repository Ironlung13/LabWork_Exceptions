using System;

namespace LabWork_Exceptions
{
    public class MatrixIndexOutOfRangeException : ApplicationException
    {
        public (int x, int y) Size { get; }
        public MatrixIndexOutOfRangeException(Matrix a)
        {
            Size = a.Size;
        }

        public MatrixIndexOutOfRangeException(Matrix a, string message) : base(message)
        {
            Size = a.Size;
        }

        public MatrixIndexOutOfRangeException(Matrix a, string message, Exception inner) : base(message, inner)
        {
            Size = a.Size;
        }
    }
}
