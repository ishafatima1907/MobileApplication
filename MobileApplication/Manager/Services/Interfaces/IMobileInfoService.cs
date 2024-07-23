using MobileApplication.DbModels;
using MobileApplication.Manager.DTOs;

namespace MobileApplication.Manager.Services.Interfaces
{
    public interface IMobileInfoService
    {
        Task<IEnumerable<MobileInfoDto>> GetAllMobilesAsync();
        Task<MobileInfoDto> GetMobileByIdAsync(int id);
        Task AddMobileAsync(MobileInfo mobileinfo);
        Task AddMobileAsync(MobileInfoCreateUpdateDto mobileDto);
        Task UpdateMobileAsync(int id, MobileInfoCreateUpdateDto mobileDto);
        Task DeleteMobileAsync(int id);
    }
}
