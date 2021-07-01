namespace LibraryManagement.Domain
{
    public interface IBook
    {
        int Id { get; set; }
        string ISBN { get; set; }
        string Title { get; set; }
        string Author { get; set; }
    }
}
