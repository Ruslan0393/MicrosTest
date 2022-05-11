using MicrosTest.Domain;
using MicrosTest.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosTest.Data.IRepositories
{
    public interface IUserRepository
    {
        void Create(User user);

        IList<User> GetAll();
    }
}
