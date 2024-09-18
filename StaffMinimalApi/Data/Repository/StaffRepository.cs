using MongoDB.Bson;
using MongoDB.Driver;
using StaffMinimalApi.Data.Context;
using StaffMinimalApi.Models;

namespace StaffMinimalApi.Data.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly IStaffContext _context;
        public StaffRepository(IStaffContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StaffModel>> GetAll()
        {
            return await _context
                            .Equipe
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<StaffModel> GetOne(long id)
        {
            var filter = this.FindById(id);
            return _context
                    .Equipe
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task Create(StaffModel staff)
        {
            await _context.Equipe.InsertOneAsync(staff);
        }
        public async Task<bool> Update(StaffModel staff)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Equipe
                        .ReplaceOneAsync(
                            filter: g => g.Id == staff.Id,
                            replacement: staff);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            var filter = this.FindById(id);
            DeleteResult deleteResult = await _context
                                              .Equipe
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        private FilterDefinition<StaffModel> FindById(long id)
        {
            return Builders<StaffModel>.Filter.Eq(m => m.Id, id);
        }
        public async Task<long> GetNextId()
        {
            return await _context.Equipe.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
