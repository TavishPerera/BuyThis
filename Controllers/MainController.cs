using BuyThis.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BuyThis.Data;
using BuyThis.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BuyThis.Controllers
{
    
    public class MainController : Controller
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<MainController> _logger;
        private readonly UserManager<User> _userManager;

        public MainController(IRepository repository, IMapper mapper, ILogger<MainController> logger, UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            //_context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Welcome to";
            var results = _repository.GetAllProducts();
            return View(results);
        }

        [Authorize]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();

            return View(results);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var user = new User
                    {
                        UserName = model.UserName,
                        FirstName = model.UserFName,
                        LastName = model.UserLName,
                        Email = model.UserEmail,
                        PhoneNumber = model.UserPhoneNumber
                    };

                    var result = await _userManager.CreateAsync(user,model.UserPassword);

                    if (result.Succeeded)
                    {
                        ViewBag.UserMessage = "Registered Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to register user:{ex}");
            }
            return View();
        }
    }
}