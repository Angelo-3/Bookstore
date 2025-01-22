using Bookstore.Interfaces;

namespace Bookstore.@class
{
    [Serializable]
    public abstract class User
    {
        private static List<User> users = new List<User>();

        private string name;
        private string phoneNumber;
        private string email;
        private DateTime dateOfBirth;
        private string address;
        public Customer CustomerRole { get; private set; }
        public Employee EmployeeRole { get; private set; }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                name = value;
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phone number cannot be empty.");
                }
                phoneNumber = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value) || !value.Contains("@"))
                {
                    throw new ArgumentException("Invalid email address.");
                }
                email = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                if (DateTime.Today < value)
                {
                    throw new ArgumentException("Invalid date of birth.");
                }
                dateOfBirth = value;
            }
        }

        public User(string name, string phoneNumber, string email, DateTime dateOfBirth)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
            users.Add(this);
        }

        public User(string name, string phoneNumber, string email, DateTime dateOfBirth,
            bool isCustomer = false, bool isEmployee = false, string position = null)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = dateOfBirth;

            if (isCustomer)
            {
                AssignCustomerRole();
            }

            if (isEmployee)
            {
                if (string.IsNullOrEmpty(position))
                    throw new ArgumentException("Position must be provided for Employee role.");
                AssignEmployeeRole(position);
            }

            users.Add(this);
        }

        public void AssignCustomerRole()
        {
            if (CustomerRole != null)
                throw new InvalidOperationException("Customer role already assigned.");

            CustomerRole = new Customer(name, phoneNumber, email, dateOfBirth, address);
        }

        public void AssignEmployeeRole(string position)
        {
            if (EmployeeRole != null)
                throw new InvalidOperationException("Employee role already assigned.");

            EmployeeRole = new Employee(name, phoneNumber, email, dateOfBirth, position);
        }

        public void RemoveCustomerRole()
        {
            if (CustomerRole == null)
                throw new InvalidOperationException("Customer role not assigned.");

            CustomerRole = null;
        }

        public void RemoveEmployeeRole()
        {
            if (EmployeeRole == null)
                throw new InvalidOperationException("Employee role not assigned.");

            EmployeeRole = null;
        }

        public static void ClearUsers()
        {
            users.Clear();
        }
        public static List<User> GetUsers()
        {
            return new List<User>(users);
        }

        public abstract void assignOrder(Order order);
        public abstract void addDiscount (Discount discount);
  
        /*public static void Add(User user)
        {
            users.Add(user);
        }*/
    }
}
