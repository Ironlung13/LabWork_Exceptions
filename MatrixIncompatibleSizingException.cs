using System;

namespace LabWork_Exceptions
{
    class MatrixIncompatibleSizingException : Exception
    {
        public (uint x, uint y) Size1 { get; }
        public (uint x, uint y) Size2 { get; }
        public MatrixIncompatibleSizingException(Matrix a, Matrix b)
        {
            Size1 = a.Size;
            Size2 = b.Size;
        }

        public MatrixIncompatibleSizingException(Matrix a, Matrix b, string message) : base(message)
        {
            Size1 = a.Size;
            Size2 = b.Size;
        }

        public MatrixIncompatibleSizingException(Matrix a, Matrix b, string message, Exception inner) : base(message, inner)
        {
            Size1 = a.Size;
            Size2 = b.Size;
        }
    }
}
