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

        public void AddEntity(object model)
        {
            _context.Add(model);
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

        public Product GetProductByID(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

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

        public string NextNumber()
        {
            string number = "";
            var result = (from e in _context.Orders
                          orderby e.OrderNumber descending
                          select e.OrderNumber).FirstOrDefault();

            if (result == null)
            {
                number = "1000001";
            }
            else
            {
                int x = (int)Int64.Parse(number);
                int z = x + 1;
                number = z.ToString();
            }
            return number;
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
                .Where(o => o.Id == id && o.User.UserName == userEmail)
                .FirstOrDefault();
        }

        public void AddOrder(Order newOrder)
        {
           foreach(var item in newOrder.Items)
            {
                item.Product = _context.Products.Find(item.Product.ProductId);
            } 
           AddEntity(newOrder);
        }
    }
}