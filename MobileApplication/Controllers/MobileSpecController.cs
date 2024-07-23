using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MobileApplication.DbModels;
using MobileApplication.Infrastructure.Repository.Interfaces;
using MobileApplication.Manager.DTOs;

namespace MobileApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MobileSpecController : Controller
    {
        private readonly IMobileSpecsService _specsService;

        public MobileSpecController(IMobileSpecsService specsService)
        {
            _specsService = specsService;
        }
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobileSpec>>> GetAllByMobileInfoIdAsync(int mobileInfoId)
        {
            var specs = await _specsService.GetAllByMobileInfoIdAsync(mobileInfoId);
            return Ok(specs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MobileSpecsDto>> GetSpecsByIdAsync(int id)
        {
            var specs = await _specsService.GetSpecsByIdAsync(id);

            if (specs == null)
            {
                return NotFound();
            }

            return Ok(specs);
        }
     
        [HttpPost] 
        public async Task<ActionResult> AddSpecsAsync(MobileSpecsDto specs)
        {
            await _specsService.AddSpecsAsync(specs);
            return StatusCode(StatusCodes.Status201Created, "Created successfully");
        }
       

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSpecs(int id, MobileSpecsDto specsDto)
        {
            await _specsService.UpdateSpecsAsync(id, specsDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSpecs(int id)
        {
            await _specsService.DeleteSpecsAsync(id);
            return NoContent();
        }
    } 
} 
