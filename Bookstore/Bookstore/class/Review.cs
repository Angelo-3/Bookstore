﻿namespace Bookstore.@class
{
    [Serializable]
    public class Review
    {
        private static List<Review> reviews = new List<Review>();

        private int rating;
        private string comment;
        private DateTime reviewDate;

        public int Rating
        {
            get => rating;
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Rating must be between 1 and 5.");
                }
                rating = value;
            }
        }

        public string Comment
        {
            get => comment;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Comment cannot be empty.");
                }
                comment = value;
            }
        }

        public DateTime ReviewDate
        {
            get => reviewDate;
            //To check with team
            set
            {
                if (DateTime.Today < value)
                {
                    throw new ArgumentException("Invalid review date.");
                }
                reviewDate = value;
            }
        }

        public Review(int rating, string comment, DateTime reviewDate)
        {
            Rating = rating;
            Comment = comment;
            ReviewDate = reviewDate;
            reviews.Add(this);
        }

        public static void ClearReviews()
        {
            reviews.Clear();
        }
        public static List<Review> GetReviews()
        {
            return new List<Review>(reviews);
        }
        /*public static void Add(Review review)
        {
            reviews.Add(review);
        }*/
    }
}
