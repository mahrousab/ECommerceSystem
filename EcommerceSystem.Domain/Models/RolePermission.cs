using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceSystem.Domain.Models
{
    public class RolePermission
    {
        public Guid RoleId { get; set; }
        public Permission Permission { get; set; } = null!;
    }
}
