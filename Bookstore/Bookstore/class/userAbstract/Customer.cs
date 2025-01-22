using Bookstore.Interfaces;

namespace Bookstore.@class
{
    public class Customer : User, ICustomerRole
    {
        private List<Discount> associatedDiscounts = new List<Discount>();
        public IReadOnlyList<Discount> getAssociatedDiscounts() => associatedDiscounts.AsReadOnly();

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address cannot be empty.");
                }
                _address = value;
            }
        }

        public Customer(string name, string phoneNumber, string email, DateTime dateOfBirth, string address)
            : base(name, phoneNumber, email, dateOfBirth)
        {
            Address = address;
        }

        public override void addDiscount(Discount discount)
        {
            if (!associatedDiscounts.Contains(discount))
            {
                associatedDiscounts.Add(discount);
                discount.addCustomer(this);
            }
        }

        public override void assignOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void removeDiscount(Discount discount)
        {
            if (associatedDiscounts.Contains(discount))
            {
                associatedDiscounts.Remove(discount);
                discount.removeCustomer(this);
            }
        }
        public void removeAllDiscounts()
        {
            foreach (Discount discount in associatedDiscounts)
            {
                removeDiscount(discount);
            }
        }
    }
}
