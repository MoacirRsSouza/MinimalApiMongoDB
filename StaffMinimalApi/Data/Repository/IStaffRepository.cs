using StaffMinimalApi.Models;

namespace StaffMinimalApi.Data.Repository
{
    public interface IStaffRepository
    {
        Task<IEnumerable<StaffModel>> GetAll();
        Task<StaffModel> GetOne(long id);
        Task Create(StaffModel staff);
        Task<bool> Update(StaffModel staff);
        Task<bool> Delete(long id);
        Task<long> GetNextId();
    }
}
