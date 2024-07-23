using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MobileApplication.DbModels;
using MobileApplication.Infrastructure.Repository.Interfaces;
using MobileApplication.Manager.DTOs;

namespace MobileApplication.Manager.Services.Implementations
{
    public class MobileSpecsService : IMobileSpecsService
    {
        private readonly IMobileSpecsRepository _specsRepository;
        private readonly IMapper _mapper;

        public MobileSpecsService(IMobileSpecsRepository specsRepository, IMapper mapper)
        {
            _specsRepository = specsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MobileSpecsDto>> GetAllByMobileInfoIdAsync(int mobileInfoId)
        {
            var mobileSpecs = await _specsRepository.GetAllByMobileInfoIdAsync(mobileInfoId);
            return _mapper.Map<IEnumerable<MobileSpecsDto>>(mobileSpecs);
        }

        public async Task<MobileSpecsDto> GetSpecsByIdAsync(int id)
        {
            var specs = await _specsRepository.GetSpecsByIdAsync(id);
            return _mapper.Map<MobileSpecsDto>(specs);
        }

        public async Task AddSpecsAsync(MobileSpecsDto specs)
        {
            var mobileSpecs = _mapper.Map<MobileSpec>(specs);
            await _specsRepository.AddSpecsAsync(mobileSpecs);
        }
      
        public async Task UpdateSpecsAsync(MobileSpecsDto specs)
        {
            var mobileSpecs = _mapper.Map<MobileSpec>(specs);
            await _specsRepository.UpdateSpecsAsync(mobileSpecs);
        }

        public async Task DeleteSpecsAsync(int id)
        {
            await _specsRepository.DeleteSpecsAsync(id);
        }
    }
}
