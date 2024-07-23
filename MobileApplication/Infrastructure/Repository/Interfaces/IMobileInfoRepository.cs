using MobileApplication.DbModels;

namespace MobileApplication.Infrastructure.Repository.Interfaces
{
    public interface IMobileInfoRepository
    {
        Task<IEnumerable<MobileInfo>> GetAllMobilesAsync();
        Task<MobileInfo> GetMobileByIdAsync(int id);
        Task AddMobileAsync(MobileInfo mobile);
        Task UpdateMobileAsync(MobileInfo mobile);
        Task DeleteMobileAsync(int id);
    }
}
