using AutoMapper;
using BuyThis.Data;
using BuyThis.Models;
using BuyThis.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BuyThis.Controllers
{
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public UserController(IRepository repository, ILogger<ProductController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        

        //[HttpPost]
        //public IActionResult Register([FromBody]UserViewModel model)
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
