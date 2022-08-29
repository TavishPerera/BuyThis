using BuyThis.Data;

namespace BuyThis.Models
{
    public interface IRepository
    {
        IEnumerable<Product> GetAllProducts();
        bool SaveAll();
        void AddUser(object model);
        void AddOrder(object model);
        void AddLoginDetails(object model);
        void AddCart(object model);
        int NextUserNumber();
        int NextUserId();
        Product GetProductByID(int id);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItem);
        Order GetOrderById(string userName, int id);
        void AddOrder(Order newOrder);
        User GetUserByID(int id);
    }
}