using System;

namespace Infrastructure.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        #region Constructors

        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundException(Exception ex)
            : base(ex.Message)
        {
        }

        #endregion
    }
}
