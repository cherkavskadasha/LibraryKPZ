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
        private readonly LoanRepository _loanRepo = new LoanRepository();

        public void LoanBook(int userId, int bookId)
        {
            var loan = new Loan { UserId = userId, BookId = bookId, Date = DateTime.Now };
            _loanRepo.Add(loan);
        }

        public List<Loan> GetAllLoans() => _loanRepo.GetAll();
    }
}

