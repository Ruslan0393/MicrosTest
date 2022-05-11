using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MicrosTest.DTO.Users;
using MicrosTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var resalt = userService.GetAll();
            var users = new GetUserDto()
            {
                Users = resalt,
                Title = "All users"
            };
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                userService.Create(createUserDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
