using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceSystem.Application.Auth
{
    public class RegisterRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
