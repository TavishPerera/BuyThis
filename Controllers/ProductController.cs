using BuyThis.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyThis.Controllers
{
    [Route("api/[Controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IRepository repository, ILogger<ProductController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called in API");
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products:{ex}");
                return BadRequest("Failed to get products");
            }
        }

        //[HttpGet("{id:int}")]
        //public IActionResult GetByID(int id)
        //{
        //    try
        //    {
        //        _logger.LogInformation("GetByID was called in API");
        //        return Ok(_repository.GetProductByID(id));

        //    }
        //    catch(Exception ex)
        //    {
        //        _logger.LogError($"Failed to get products:{ex}");
        //        return BadRequest("Failed to get products");
        //    }
        //}
    }
}