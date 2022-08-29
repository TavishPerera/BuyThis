using BuyThis.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BuyThis.Data;
using BuyThis.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BuyThis.Controllers
{
    
    public class MainController : Controller
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<MainController> _logger;
        //private readonly BuyThisContext _context;

        public MainController(IRepository repository, IMapper mapper, ILogger<MainController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            //_context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Welcome to";
            var results = _repository.GetAllProducts();
            return View(results);
        }

        //public IActionResult ProductPage(int id)
        //{
        //    var results = _repository.GetProductByID(id);
        //    return View(results);
        //}

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
        public IActionResult Register(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int num = _repository.NextUserNumber();
                    int id = _repository.NextUserId();

                    User user = new()
                    {
                        UserId = id,
                        UserEmail = model.UserEmail,
                        UserFName = model.UserFName,
                        UserNumber = num,
                        UserPhoneNumber = model.UserPhoneNumber,
                        UserLName = model.UserLName,
                        UserRole = "Customer",
                        UserPassword = model.UserPassword
                    };

                    _repository.AddUser(user);
                    if (_repository.SaveAll())
                    {
                        ViewBag.UserMessage = "Registered Successfully";

                        Login login = new()
                        {
                            UserNumber = num,
                            UserEmail = model.UserEmail,
                            UserPhoneNumber = model.UserPhoneNumber,
                            UserPassword = model.UserPassword
                        };

                        _repository.AddLoginDetails(login);
                        if (_repository.SaveAll())
                        {
                            _logger.LogInformation("User Credentials Added");

                            AddCartDetails(user.UserId, num);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to register user:{ex}");
            }
            return View();
        }

        public void AddCartDetails(int id, int num)
        {
            Cart cart = new()
            {
                CartNumber = num,
                UserID = id,
                CartQty = 0,
                CartTotal = 0
            };

            _repository.AddCart(cart);
            if (_repository.SaveAll())
            {
                _logger.LogInformation("User Cart Details Added");
            }
        }

        //[HttpPost]
        //public IActionResult Register([FromBody] UserViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var newUser = _mapper.Map<UserViewModel, User>(model);

        //            _logger.LogInformation("Register was called in API");

        //            _repository.AddUser(newUser);

        //            if (_repository.SaveAll())
        //            {
        //                var map = _mapper.Map<User, UserViewModel>(newUser);
        //                return Created($"/api/user/{newUser.UserId}", _mapper.Map<User, UserViewModel>(newUser));
        //            }
        //        }
        //        else
        //        {
        //            return BadRequest(ModelState);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to register user:{ex}");

        //    }
        //    return BadRequest("Failed to register in API");
        //}
    }
}
