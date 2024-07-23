using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileApplication.DbModels;
using MobileApplication.Infrastructure.Repository.Interfaces;
using MobileApplication.Manager.DTOs;
using MobileApplication.Manager.Services.Interfaces;
using Services.Managers.Interfaces;

namespace MobileApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMobileInfoService _mobileInfoService;
        private readonly ITokenService _tokenService;

        public AuthController(IMobileInfoService mobileInfoService , ITokenService tokenService)
        { 
            _mobileInfoService = mobileInfoService;
            _tokenService = tokenService;
        }
        
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToken(int id)
        {
            var mobile = await _mobileInfoService.GetMobileByIdAsync(id);
            if (mobile == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = _tokenService.GetTokenAsync(id) });
        }
    } 
}