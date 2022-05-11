using MicrosTest.Data.IRepositories;
using MicrosTest.Domain;
using MicrosTest.DTO.Users;
using MicrosTest.Service.Interfaces;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosTest.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IWebHostEnvironment webHost;

        public UserService(IUserRepository userRepository, IWebHostEnvironment webHost )
        {
            this.userRepository = userRepository;
            this.webHost = webHost;
        }

        public void Create(CreateUserDto createUser)
        {
            User user = new User();
            user.Fullname = createUser.Fullname;
            user.Email = createUser.Email;
            user.Facebook = createUser.Facebook;
            user.Twitter = createUser.Twitter;
            user.Username = createUser.Username;
            user.Info = createUser.Info;
            user.Image = UploadImage(createUser);

            userRepository.Create(user);
        }

        public IList<User> GetAll()
           => userRepository.GetAll();

        public string UploadImage(CreateUserDto userDto)
        {
            string fileName = string.Empty;
            if(userDto.Image is not null)
            {
                string uploadFolder = Path.Combine(webHost.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "_" + userDto.Image.FileName;
                string imageFilePath = Path.Combine(uploadFolder, fileName);
                using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
                {
                    userDto.Image.CopyTo(fileStream);
                }
            }

            return fileName;

        }
    }
}
