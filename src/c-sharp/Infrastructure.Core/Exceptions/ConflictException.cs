using System;
using System.Collections.Generic;

namespace Infrastructure.Core.Exceptions
{
    public class ConflictException : Exception
    {
        #region Fields

        public Dictionary<string, List<string>> Errors { get; set; }

        #endregion

        #region Constructors

        public ConflictException()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public ConflictException(string message)
            : base(message)
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public ConflictException(string message, Exception innerException)
            : base(message, innerException)
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public ConflictException(Exception ex)
            : base(ex.Message)
        {
            Errors = new Dictionary<string, List<string>>();
        }


        public ConflictException(Dictionary<string, List<string>> errors)
        {
            Errors = errors;
        }

        public ConflictException(string message, Dictionary<string, List<string>> errors)
            : base(message)
        {
            Errors = errors;
        }

        public ConflictException(string message, Exception innerException, Dictionary<string, List<string>> errors)
            : base(message, innerException)
        {
            Errors = errors;
        }

        public ConflictException(Exception ex, Dictionary<string, List<string>> errors)
            : base(ex.Message)
        {
            Errors = errors;
        }

        #endregion
    }
}
