using MobileApplication.DbModels;
using MobileApplication.Manager.DTOs;

namespace MobileApplication.Infrastructure.Repository.Interfaces
{
    public interface IMobileSpecsService
    {
        Task<IEnumerable<MobileSpecsDto>> GetAllByMobileInfoIdAsync(int mobileInfoId);
        Task<MobileSpecsDto> GetSpecsByIdAsync(int id);
        Task AddSpecsAsync(MobileSpecsDto specs);
        Task UpdateSpecsAsync(MobileSpecsDto specs);
        Task DeleteSpecsAsync(int id);
    }
}
