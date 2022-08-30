using BuyThis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BuyThis.Models
{
    public class Repository : IRepository
    {
        private readonly BuyThisContext _context;
        private readonly ILogger<Repository> _logger;

        public Repository(BuyThisContext context, ILogger<Repository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            _logger.LogInformation("GetAllProducts was called in Repository");
            return _context.Products.OrderBy(p => p.ProductName).ToList();
        }

        public bool SaveAll()
        {
            _logger.LogInformation("SaveAll was called in Repository");
            _context.SaveChanges();
            return true;
        }

        public void AddUser(object model)
        {
            _logger.LogInformation("AddUser was called in Repository");
            _context.Add(model);

            
        }

        public void AddLoginDetails(object model)
        {
            _logger.LogInformation("AddLoginDetails was called in Repository");
            _context.Add(model);
        }

        public void AddCart(object model)
        {
            _logger.LogInformation("AddCart was called in Repository");
            _context.Add(model);
        }
        public void AddOrder(object model)
        {
            _logger.LogInformation("AddOrder was called in Repository");
            _context.Add(model);
        }

        //public int NextUserNumber()
        //{
        //    var result = (from u in _context.Users
        //                  orderby u.UserNumber descending
        //                  select u.UserNumber).FirstOrDefault();

        //    if(result == 0)
        //    {
        //        return 10000001;
        //    }
        //    else
        //    {
        //        return result + 1;
        //    }
        //}

        //public int NextUserId()
        //{
        //    var result = (from u in _context.Users
        //                  orderby u.UserId descending
        //                  select u.UserId).FirstOrDefault();

        //    if (result == 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return result + 1;
        //    }
        //}

        public Product GetProductByID(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

        //public User GetUserByID(int id)
        //{
        //    return _context.Users.Where(u => u.UserId == id).FirstOrDefault();
        //}

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                    .ToList();
            }
            else
            {
                return _context.Orders.ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string userEmail, bool includeItem)
        {
            if (includeItem)
            {
                return _context.Orders
                    .Where(o => o.User.UserName == userEmail)
                    .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                    .ToList();
            }
            else
            {
                return _context.Orders
                    .Where(o => o.User.UserName == userEmail)
                    .ToList();
            }
        }

        public Order GetOrderById(string userEmail, int id)
        {
            return _context.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.OrderId == id && o.User.UserName == userEmail)
                .FirstOrDefault();
        }

        public void AddOrder(Order newOrder)
        {
           foreach(var item in newOrder.Items)
            {
                item.Product = _context.Products.Find(item.Product.ProductId);
            } 
           AddOrder(newOrder);
        }
    }
}