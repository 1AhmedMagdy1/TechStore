using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOS
{
    public class RegisterDTO
    {
        [Required]
        [Length(3, 50, ErrorMessage = "Username must be 3-50 chars")]
        public string UserName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8, ErrorMessage = "Password must be at least 8 chars")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^01[0125][0-9]{8}$")]
        public string PhoneNumber { get; set; }
    }
}
