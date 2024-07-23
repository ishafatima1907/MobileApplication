using MobileApplication.DbModels;
using MobileApplication.Manager.DTOs;

namespace Services.Managers.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(int id);
    }
}
