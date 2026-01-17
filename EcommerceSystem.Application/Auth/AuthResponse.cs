using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceSystem.Application.Auth
{
    public class AuthResponse
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }

        public AuthResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
