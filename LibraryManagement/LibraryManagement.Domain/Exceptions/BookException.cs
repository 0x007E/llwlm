namespace LibraryManagement.Domain.Exceptions
{
    public class BookException : Exception
    {
        public BookException(string accessor, string message) : base(message) => Accessor = accessor;

        public string Accessor  { get; set; }

        public override string ToString() => $"{Accessor}: {base.Message}";
    }
}