namespace Mission11Books_Hawkins.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
