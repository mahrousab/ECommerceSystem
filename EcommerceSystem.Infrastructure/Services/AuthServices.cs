using Azure.Core;
using Ecommerce.Domain.Models;
using EcommerceSystem.Application.Auth;
using EcommerceSystem.Application.IServices;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;
using ECommerceSystem.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceSystem.Infrastructure.Services
{
    public class AuthServices : IAuthService
    {
        private readonly TokenService _tokenService;

        private readonly UserManager<User> _userManager;

        private readonly ECommerceSystemDbContext _context;
        public AuthServices(TokenService token, UserManager<User> usermanger, ECommerceSystemDbContext context) { 
        
          _context = context;
            _tokenService = token;
            _userManager = usermanger;

        }
        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                throw new UnauthorizedAccessException();
            var roles = await _userManager.GetRolesAsync(user);

            var accessToken = _tokenService.CreateAccessToken(user, roles);
            var refreshToken = _tokenService.CreateRefreshToken();

            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new AuthResponse(accessToken, refreshToken.Token);
        }
        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var user = _context.Users
            .Include(u => u.RefreshTokens)
            .SingleOrDefault(u =>
                u.RefreshTokens.Any(t => t.Token == refreshToken && !t.IsRevoked));

            if (user == null)
                throw new UnauthorizedAccessException();

            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _tokenService.CreateAccessToken(user, roles);

            return new AuthResponse(accessToken, refreshToken);
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new ApplicationException(
                    string.Join(",", result.Errors.Select(e => e.Description)));

            // Default Role
            await _userManager.AddToRoleAsync(user, "User");
        }
        

    }
}
