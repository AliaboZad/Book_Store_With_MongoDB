namespace MongoDB_Asp.netAPI.Model
{
    public class BookStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string BooksCollectionName { get; set; } = null!;

    }
}
