using MicrosTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosTest.DTO.Users
{
    public class GetUserDto
    {
        public IList<User> Users { get; set; }
        public string Title { get; set; }
    }
}
