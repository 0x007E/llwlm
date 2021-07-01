using System;

namespace LibraryManagement.Domain.Exceptions
{
    public class BookException : Exception
    {
        public BookException(string accessor, string message) : base(message) => this.Accessor = accessor;

        public string Accessor { get; set; }

        public override string Message => $"{this.Accessor}: {base.Message}";
    }
}
