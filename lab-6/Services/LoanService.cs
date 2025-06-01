using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_6.Models;
using lab_6.Repositories;

namespace lab_6.Services
{
    public class LoanService
    {
        private readonly LoanRepository _loanRepository;
        private readonly BookService _bookService;
        private readonly LoanRepository _loanRepo = new LoanRepository();

        public LoanService()
        {
            _loanRepository = new LoanRepository();
            _bookService = new BookService();
        }
        public void LoanBook(int userId, int bookId)
        {
            var loans = GetAllLoans();

            var book = _bookService.GetAllBooks().FirstOrDefault(b => b.Id == bookId);
            if (book == null || !book.IsAvailable)
            {
                Console.WriteLine("Книга недоступна для видачі.");
                return;
            }

            loans.Add(new Loan { UserId = userId, BookId = bookId, Date = DateTime.Now });
            SaveAllLoans(loans);

            book.IsAvailable = false;
            _bookService.UpdateBook(book);

            Console.WriteLine($"Книга з ID {bookId} видана користувачу з ID {userId}.");
        }
        public List<Loan> GetAllLoans()
        {
            return _loanRepository.GetAll();
        }

        public void SaveAllLoans(List<Loan> loans)
        {
            _loanRepository.SaveAll(loans);
        }
        public void ReturnBook(int bookId)
        {
            var loans = GetAllLoans();
            var loan = loans.FirstOrDefault(l => l.BookId == bookId);
            if (loan != null)
            {
                loans.Remove(loan);
                SaveAllLoans(loans);

                var book = _bookService.GetAllBooks().FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    book.IsAvailable = true;
                    _bookService.UpdateBook(book);
                }

                Console.WriteLine($"Книга з ID {bookId} повернена.");
            }
            else
            {
                Console.WriteLine("Ця книга не була видана.");
            }
        }

    }
}

