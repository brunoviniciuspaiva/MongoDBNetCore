using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Data.Context
{
    public class MongoDBContext<T>: DbContext
    {
        public IMongoCollection<T> _context;

        public MongoDBContext(IConfiguration configuration)
        {
#if DEBUG
            MongoClient client = new MongoClient(configuration.GetConnectionString("MongoDB-DEV"));
#else
            MongoClient client = new MongoClient(configuration.GetConnectionString("MongoDB-PROD"));
#endif
            IMongoDatabase database = client.GetDatabase(configuration["DataBase"]);
            _context = database.GetCollection<T>(typeof(T).Name);
        }
    }
}
