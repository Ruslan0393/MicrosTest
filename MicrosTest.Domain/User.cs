using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosTest.Domain
{
    public class User
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Info { get; set; }
        public string Username { get; set; }
        public DateTime LastTimeAccess { get; set; }
        public string Image { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Email { get; set; }
    }
}
