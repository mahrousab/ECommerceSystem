using Ecommerce.Domain.Models;
using EcommerceSystem.Application.Auth;
using EcommerceSystem.Application.IServices;
using EcommerceSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using LoginRequest = EcommerceSystem.Application.Auth.LoginRequest;
using RegisterRequest = EcommerceSystem.Application.Auth.RegisterRequest;

namespace EcommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthnticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfigurationManager _configurationManager;
        private readonly ECommerceSystemDbContext _context;


        public AuthnticationController(UserManager<User> usermanger, RoleManager<IdentityRole> roleManager, 
            IConfigurationManager configurationManager, IAuthService authService,ECommerceSystemDbContext context)
        {
            _userManager = usermanger;
            _roleManager = roleManager;
            _configurationManager = configurationManager;
            _authService = authService;
            _context = context;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await _authService.RegisterAsync(request);
            return Ok("User registered successfully");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            return Ok(await _authService.LoginAsync(request));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            return Ok(await _authService.RefreshTokenAsync(refreshToken));
        }
        /*
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(RefreshRequest dto)
        {
            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == dto.RefreshToken);

            if (token == null) return BadRequest();

            token.IsRevoked = true;
            await _context.SaveChangesAsync();

            return Ok();
        }
        */
    }
}
