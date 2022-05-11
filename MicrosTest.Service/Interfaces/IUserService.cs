using MicrosTest.Domain;
using MicrosTest.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosTest.Service.Interfaces
{
    public interface IUserService
    {
        IList<User> GetAll();
        void Create(CreateUserDto createUserDto);
    }
}
