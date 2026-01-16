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
        private readonly BookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public void AddBook(string title, string author)
        {
            var book = new Book { Title = title, Author = author };
            _bookRepository.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }
        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

    }
}

