using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using RegisterMicroservice.DataBaseSettings;
using RegisterMicroservice.Models;


namespace RegisterMicroservice.Services
{
    public class UserRegisterMicroservice
    {
        private readonly IMongoCollection<User> _UsersCollection;

        public UserRegisterMicroservice(IOptions<DatabaseSettingsApp> settings)
        
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

        //guardar usuario    
        public async Task CreateUser(User user)
        {
            await _UsersCollection.InsertOneAsync(user);
        }
    }
}
