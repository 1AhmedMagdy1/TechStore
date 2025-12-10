using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOS
{
    public class CreateUserDTO
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? Token { get; set; }

    }
}
