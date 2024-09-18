using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StaffMinimalApi.Models;

namespace StaffMinimalApi.Data.Context
{
    public class StaffContext : IStaffContext
    {
        private readonly IMongoDatabase _db;
        public StaffContext(IOptions<MongoConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            _db = client.GetDatabase(config.Value.Database);
        }
        public IMongoCollection<StaffModel> Equipe => _db.GetCollection<StaffModel>("staff");
    }
}
