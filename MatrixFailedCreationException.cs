using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork_Exceptions
{
    public class MatrixFailedCreationException : Exception
    {
        public (int x, int y) Size { get; }
        public MatrixFailedCreationException((int x, int y) size)
        {
            Size = size;
        }

        public MatrixFailedCreationException((int x, int y) size, string message) : base(message)
        {
            Size = size;
        }

        public MatrixFailedCreationException((int x, int y) size, string message, Exception inner) : base(message, inner)
        {
            Size = size;
        }
    }
}
