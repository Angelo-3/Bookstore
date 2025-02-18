﻿namespace Bookstore.@class
{
    [Serializable]
    public class Wishlist
    {
        private List<Book> associatedBooks = new List<Book>();
        public IReadOnlyList<Book> getAssociatedBooks() => associatedBooks.AsReadOnly();
        private int maxCapacity = 1000;

        public int MaxCapacity
        {
            get => maxCapacity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Max capacity must be greater than zero.");
                }
                maxCapacity = value;
            }
        }

        public Wishlist()
        {
        }
        public void addBook(Book book)
        {
            if (!associatedBooks.Contains(book))
            {
                associatedBooks.Add(book);
                book.assignToWishlist(this);
            }
        }
        public void removeBook(Book book)
        {
            if (associatedBooks.Contains(book))
            {
                associatedBooks.Remove(book);
                book.removeFromWishlist(this);
            }
        }
        public void removeAllBooks()
        {
            foreach (Book book in associatedBooks)
            {
                removeBook(book);
            }
        }
    }
}