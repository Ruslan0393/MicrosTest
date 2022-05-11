using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosTest.DTO.Users
{
    public class CreateUserDto
    {
        public string Fullname { get; set; }
        public string Info { get; set; }
        public string Username { get; set; }
        public IFormFile Image { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Email { get; set; }
    }
}
