using Microsoft.EntityFrameworkCore;
using MobileApplication.DbModels;
using MobileApplication.Infrastructure.Configuration;
using MobileApplication.Infrastructure.Repository.Interfaces;

namespace MobileApplication.Infrastructure.Repository.Implementations
{
    public class MobileInfoRepository : IMobileInfoRepository
    {
        private readonly MobilesDbContext _context;

        public MobileInfoRepository(MobilesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MobileInfo>> GetAllMobilesAsync()
        {
            return await _context.MobileInfos.Include(m => m.MobileSpecs).ToListAsync();
        }

        public async Task<MobileInfo> GetMobileByIdAsync(int id)
        {
            return await _context.MobileInfos.Include(m => m.MobileSpecs)
                                             .FirstOrDefaultAsync(m => m.MobileInfoId == id);
        }

        public async Task AddMobileAsync(MobileInfo mobile)
        {
            await _context.MobileInfos.AddAsync(mobile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMobileAsync(MobileInfo mobile)
        {
            _context.MobileInfos.Update(mobile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMobileAsync(int id)
        {
            var mobile = await _context.MobileInfos.FindAsync(id);
            _context.MobileInfos.Remove(mobile);
            await _context.SaveChangesAsync();
        }
    }
}
