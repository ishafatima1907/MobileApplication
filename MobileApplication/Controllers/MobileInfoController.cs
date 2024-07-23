using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileApplication.DbModels;
using MobileApplication.Manager.DTOs;
using MobileApplication.Manager.Services.Interfaces;

namespace MobileApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MobileInfoController : Controller
    {
        private readonly IMobileInfoService _mobileService;

        public MobileInfoController(IMobileInfoService mobileService)
        {
            _mobileService = mobileService;
        }

        [HttpGet]
        public async Task<ActionResult<MobileInfoResponseModel>> GetAllMobilesAsync()
        {
            var mobiles = await _mobileService.GetAllMobilesAsync();
            return Ok(new MobileInfoResponseModel() { MobileInfos = mobiles });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MobileInfoDto>> GetMobileByIdAsync(int id)
        {
            var mobile = await _mobileService.GetMobileByIdAsync(id);

            if (mobile == null)
            {
                return NotFound();
            }

            return Ok(mobile);
        }
      
        [HttpPost]
        public async Task<ActionResult> CreateMobile([FromBody] MobileInfoCreateUpdateDto mobileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mobileService.AddMobileAsync(mobileDto);
            return CreatedAtAction(nameof(GetMobileByIdAsync), new { id = mobileDto.BrandName }, mobileDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMobile(int id, MobileInfoCreateUpdateDto mobileDto)
        {
            await _mobileService.UpdateMobileAsync(id, mobileDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMobile(int id)
        {
            await _mobileService.DeleteMobileAsync(id);
            return NoContent();
        }
    }
}
