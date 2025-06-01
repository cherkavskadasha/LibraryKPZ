using lab_6.Models;
using lab_6.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepo = new BookRepository();

        public void AddBook(string title, string author)
        {
            var book = new Book { Title = title, Author = author };
            _bookRepo.Add(book);
        }

        public List<Book> GetAllBooks() => _bookRepo.GetAll();
    }
}
