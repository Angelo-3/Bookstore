using Bookstore.@class;

namespace Bookstore.Interfaces
{
    public interface IEmployeeRole : IRole
    {
        void assignOrder(Order order);
        void removeAssignedOrder(Order order);
        void removeAllOrders();
    }
}
