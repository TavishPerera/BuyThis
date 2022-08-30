using BuyThis.Data;

namespace BuyThis.Models
{
    public interface IRepository
    {
        IEnumerable<Product> GetAllProducts();
        bool SaveAll();
        void AddOrder(object model);
        Product GetProductByID(int id);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItem);
        Order GetOrderById(string userName, int id);
        void AddOrder(Order newOrder);
    }
}