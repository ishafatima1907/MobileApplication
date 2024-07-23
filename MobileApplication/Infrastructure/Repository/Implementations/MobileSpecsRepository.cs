using Microsoft.EntityFrameworkCore;
using MobileApplication.DbModels;
using MobileApplication.Infrastructure.Configuration;
using MobileApplication.Infrastructure.Repository.Interfaces;

namespace MobileApplication.Infrastructure.Repository.Implementations
{
    public class MobileSpecsRepository : IMobileSpecsRepository
    {
        private readonly MobilesDbContext _context;

        public MobileSpecsRepository(MobilesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MobileSpec>> GetAllByMobileInfoIdAsync(int mobileInfoId)
        {
            return await _context.MobileSpecs
                .Where(m => m.MobileInfoId == mobileInfoId)
                .ToListAsync();
        }

        public async Task<MobileSpec> GetSpecsByIdAsync(int id)
        {
            return await _context.MobileSpecs.FirstOrDefaultAsync(x => x.MobileSpecsId == id);
        }

        public async Task AddSpecsAsync(MobileSpec specs)
        {
            await _context.MobileSpecs.AddAsync(specs);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSpecsAsync(MobileSpec specs)
        {
            _context.Entry(specs).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpecsAsync(int id)
        {
            var specs = await _context.MobileSpecs.FindAsync(id);
            _context.MobileSpecs.Remove(specs);
            await _context.SaveChangesAsync();
        }
    }
}
