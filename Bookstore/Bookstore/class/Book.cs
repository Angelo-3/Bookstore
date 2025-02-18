﻿namespace Bookstore.@class
{
    [Serializable]
    public class Book
    {
        private static List<Book> books = new List<Book>();

        private List<Wishlist> associatedWishlists = new List<Wishlist>();
        public IReadOnlyList<Wishlist> getAssociatedWishlists() => associatedWishlists.AsReadOnly();

        private List<Order> associatedOrders = new List<Order>();
        public IReadOnlyList<Order> getAssociatedOrders() => associatedOrders.AsReadOnly();

        private string title;
        private double price;
        private string languageOfPublication;
        private List<string> listOfLanguagesToWhichTranslated;

        private int lengthMax = 50;
        private int lengthMin = 3;
        private int maxPrice = 10000;

        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < lengthMin || value.Length > lengthMax)
                {
                    throw new ArgumentException($"Title must be between {lengthMin} and {lengthMax} characters.");
                }
                title = value;
            }
        }

        public double Price
        {
            get => price;
            set
            {
                if (value < 0 || value > maxPrice)
                {
                    throw new ArgumentException($"Price must be between 0 and {maxPrice}.");
                }
                price = value;
            }
        }

        public string LanguageOfPublication
        {
            get => languageOfPublication;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Language of publication cannot be empty.");
                }
                languageOfPublication = value;
            }
        }

        public List<string> ListOfLanguagesToWhichTranslated
        {
            get => new List<string>(listOfLanguagesToWhichTranslated);
            set
            {
                if (listOfLanguagesToWhichTranslated != null)
                {
                    for (int i = 0; i < listOfLanguagesToWhichTranslated.Count(); i++)
                    {
                        if (string.IsNullOrEmpty(listOfLanguagesToWhichTranslated[i]))
                        {
                            throw new ArgumentException("Translated language cannot be empty.");
                        }
                    }
                }
                listOfLanguagesToWhichTranslated = value ?? new List<string>();
            }
        }

        public Book()
        {
            ListOfLanguagesToWhichTranslated = new List<string>();
        }

        public Book(string title, double price, string languageOfPublication, List<string> listOfLanguagesToWhichTranslated = null)
        {
            Title = title;
            Price = price;
            LanguageOfPublication = languageOfPublication;
            ListOfLanguagesToWhichTranslated = listOfLanguagesToWhichTranslated ?? new List<string>();
            books.Add(this);
        }

        public static void ClearBooks()
        {
            books.Clear();
        }
        public static List<Book> GetBooks()
        {
            return new List<Book>(books);
        }
        /*public static void Add(Book book)
        {
            books.Add(book);
        }*/
        public void addLanguageToWhichTranslated(string language)
        {
            if (listOfLanguagesToWhichTranslated.Contains(language))
            {
                return;
            }
            if (string.IsNullOrEmpty(language))
            {
                throw new ArgumentException("Language to which the book was translated cannot be empty.");
            }
            listOfLanguagesToWhichTranslated.Add(language);
        }

        public bool bookPresent(Book book)
        {
            foreach (Book b in books)
            {
                if (b.title == book.title)
                {
                    return true;
                }
            }
            return false;
        }

        public void assignToWishlist(Wishlist wishlist)
        {
            if (!associatedWishlists.Contains(wishlist))
            {
                associatedWishlists.Add(wishlist);
                wishlist.addBook(this);
            }
        }
        public void removeFromWishlist(Wishlist wishlist)
        {
            if (associatedWishlists.Contains(wishlist))
            {
                associatedWishlists.Remove(wishlist);
                wishlist.removeBook(this);
            }
        }
        public void removeFromAllWishlists()
        {
            foreach (Wishlist wishlist in associatedWishlists)
            {
                removeFromWishlist(wishlist);
            }
        }

        public void assignToOrder(Order order)
        {
            if (!associatedOrders.Contains(order))
            {
                associatedOrders.Add(order);
                order.addBook(this);
            }
        }
        public void removeFromOrder(Order order)
        {
            if (associatedOrders.Contains(order))
            {
                associatedOrders.Remove(order);
                order.removeBook(this);
            }
        }
        public void removeFromAllOrders()
        {
            foreach (Order order in associatedOrders)
            {
                removeFromOrder(order);
            }
        }
    }
}
