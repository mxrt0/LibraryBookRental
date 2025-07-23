using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookRental.Models
{
    public class Book
    {
        private const string AuthorNameEmptyMessage = "Author name cannot be empty!";
        private const string BookTitleEmptyMessage = "Book title cannot be empty!";
        private readonly string _title;
        private readonly string _author;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public string Title 
        { 
            get => _title;
            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(BookTitleEmptyMessage);
                }
                _title = value;
            }
        }
        public string Author
        {
            get => _author;
            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(AuthorNameEmptyMessage);
                }
                _author = value;
            }
        }

        public bool IsAvailable
        {
            get;
            internal set;
        }

        internal void MarkAsRented()
        {
            IsAvailable = false;
        }

        internal void MarkAsReturned()
        {
            IsAvailable = true;
        }
    }
}
