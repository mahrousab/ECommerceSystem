using EcommerceSystem.Application.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceSystem.Application.IServices
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RefreshTokenAsync(string refreshToken);
        Task RegisterAsync(RegisterRequest request);
        //Task LogoutAsync(Guid userId);
    }
}
