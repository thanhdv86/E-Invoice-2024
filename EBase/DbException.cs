using System;

namespace EBase
{
    public class DbException : ApplicationException
    {
        public DbException(string Message) : base("Database Exception: " + Message)
        {
        }

        public DbException(string Message, Exception innerException) : base(Message, innerException)
        {
        }
    }
}

