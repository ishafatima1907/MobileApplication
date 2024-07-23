using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MobileApplication.DbModels;
using MobileApplication.Infrastructure.Configuration;
using MobileApplication.Infrastructure.Repository.Interfaces;
using MobileApplication.Manager.DTOs;
using MobileApplication.Manager.Services.Interfaces;

namespace MobileApplication.Manager.Services.Implementations
{
    public class MobileInfoService : IMobileInfoService
    {
        private readonly IMobileInfoRepository _mobileRepository;
        private readonly IMapper _mapper;

        public MobileInfoService(IMobileInfoRepository mobileRepository, IMapper mapper)
        {
            _mobileRepository = mobileRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MobileInfoDto>> GetAllMobilesAsync()
        {
            var mobiles = await _mobileRepository.GetAllMobilesAsync();
            return _mapper.Map<IEnumerable<MobileInfoDto>>(mobiles);
        }

        public async Task<MobileInfoDto> GetMobileByIdAsync(int id)
        {
            var mobile = await _mobileRepository.GetMobileByIdAsync(id);
            return _mapper.Map<MobileInfoDto>(mobile);
        }

        public async Task AddMobileAsync(MobileInfoCreateUpdateDto mobileDto)
        {
            var mobile = _mapper.Map<MobileInfo>(mobileDto);
            await _mobileRepository.AddMobileAsync(mobile);
        }

        public async Task UpdateMobileAsync(int id, MobileInfoCreateUpdateDto mobileDto)
        {
            var mobile = await _mobileRepository.GetMobileByIdAsync(id);
            if (mobile == null)
            {
                throw new KeyNotFoundException("Mobile not found");
            }

            _mapper.Map(mobileDto, mobile);
            await _mobileRepository.UpdateMobileAsync(mobile);
        }

        public async Task DeleteMobileAsync(int id)
        {
            await _mobileRepository.DeleteMobileAsync(id);
        }
    }
}