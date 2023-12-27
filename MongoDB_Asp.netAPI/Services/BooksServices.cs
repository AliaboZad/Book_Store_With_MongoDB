using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_Asp.netAPI.Model;

namespace MongoDB_Asp.netAPI.Services
{
    public class BooksServices
    {
        private readonly IMongoCollection<Book> _bookcollection;
        public BooksServices(IOptions<BookStoreDatabaseSettings> options    )
        {
            var mongoclient = new MongoClient(options.Value.ConnectionString);
            var mongodatabase = mongoclient.GetDatabase(options.Value.DatabaseName);
            _bookcollection = mongodatabase.GetCollection<Book>(options.Value.BooksCollectionName);
        }

        public async Task<List<Book>> GetAsync ()
            => await _bookcollection.Find(b => true).ToListAsync();

        public async Task<Book?> Getone(string id)
            => await _bookcollection.Find(b => b.Id == id).FirstOrDefaultAsync();

        public async Task CreatAsync (Book book)
            => await _bookcollection.InsertOneAsync(book);
        public async Task UpdateAsync(string id, Book book)
            => await _bookcollection.ReplaceOneAsync(b => b.Id == id, book);

        public async Task RemoveAsync (string id)
            => await _bookcollection.DeleteOneAsync(b => b.Id == id);


    }
}
