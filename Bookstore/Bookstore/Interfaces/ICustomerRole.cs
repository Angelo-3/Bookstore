using Bookstore.@class;

namespace Bookstore.Interfaces
{
    public interface ICustomerRole : IRole
    {
        void addDiscount(Discount discount);
        //void addReview(Review review);
        //void addOrder(Order order);
        //void assignWishlist(Wishlist wishlist);

    }
}
