using MobileApplication.DbModels;

namespace MobileApplication.Infrastructure.Repository.Interfaces
{
    public interface IMobileSpecsRepository
    {
        Task<IEnumerable<MobileSpec>> GetAllByMobileInfoIdAsync(int mobileInfoId);
        Task<MobileSpec> GetSpecsByIdAsync(int id);
        Task AddSpecsAsync(MobileSpec specs);
        Task UpdateSpecsAsync(MobileSpec specs);
        Task DeleteSpecsAsync(int id);
    }
}
