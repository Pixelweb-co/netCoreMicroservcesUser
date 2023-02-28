using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using SearchMicroService.DataBaseSettings;
using SearchMicroService.Models;


namespace SearchMicroService.Services
{
    public class UserSearchService
    {
        private readonly IMongoCollection<User> _UsersCollection;

        public UserSearchService(IOptions<DatabaseSettingsApp> settings)
        
        {
            

            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _UsersCollection = mongoDatabase.GetCollection<User>(
                settings.Value.UsersCollectionName);
        }

        //list users

        public List<User> Get()
        {
            
            return _UsersCollection.Find(d => true).ToList();
        }

        public IEnumerable<User> Search(string query)
        {
            var filter = Builders<User>.Filter.Regex("Nombres", new BsonRegularExpression(query, "i"))
                         | Builders<User>.Filter.Regex("Usuario", new BsonRegularExpression(query, "i"));

            return _UsersCollection.Find(filter).ToList();
        }

        public List<User> GetById(string Id)
        {
            return _UsersCollection.Find(d => d.Id == Id).ToList();
        }

    }
}
