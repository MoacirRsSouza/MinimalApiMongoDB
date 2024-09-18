using MongoDB.Driver;
using StaffMinimalApi.Models;

namespace StaffMinimalApi.Data.Context
{
    public interface IStaffContext
    {
        IMongoCollection<StaffModel> Equipe { get; }
    }
}
