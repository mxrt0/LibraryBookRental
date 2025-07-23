using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBookRental.Models;

namespace LibrarySystem.Domain.Models
{
    public class Member
    {
        private const string MemberNameEmptyMessage = "Member name cannot be empty!";
        private const string BookAlreadyRentedMessage = "'{0}' by {1} has already been rented!";
        private const string BookNotRentedMessage = "Member {0} has not rented '{1}' by {2}!";
        private readonly string _id;
        private readonly string _name;
        private readonly List<Book> _rentedBooks;

        public Member(string name)
        {
            Id = Guid.NewGuid().ToString();
            _rentedBooks = new List<Book>();
        }

        public string Id 
        {
            get => _id;
            init
            {
                _id = value;
            }
        }

        public string Name
        {
            get => _name;
            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(MemberNameEmptyMessage);
                }
                _name = value;
            }
        }

        public IReadOnlyList<Book> RentedBooks => _rentedBooks.AsReadOnly();

        public void RentBook(Book book)
        {
            if (!_rentedBooks.Contains(book))
            {
                _rentedBooks.Add(book);
                Console.WriteLine($"Member {Name} has rented '{book.Title}' by {book.Author}!");
            }
            else
            {
                throw new InvalidOperationException(string.Format(BookAlreadyRentedMessage, book.Title, book.Author));
            }
        }

        public void ReturnBook(Book book)
        {
            if (_rentedBooks.Remove(book))
            {
                Console.WriteLine($"Member {this.Name} has returned '{book.Title}' by {book.Author}!");
            }
            else
            {
                throw new InvalidOperationException(string.Format(BookNotRentedMessage, this.Name, book.Title, book.Author));
            }

        } 



    }
}
