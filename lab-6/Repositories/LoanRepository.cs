using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_6.Models;
using lab_6.Utils;

namespace lab_6.Repositories
{
    public class LoanRepository
    {
        private const string FilePath = "loans.json";

        public List<Loan> GetAll() => FileHelper.Load<List<Loan>>(FilePath) ?? new List<Loan>();

        public void SaveAll(List<Loan> loans) => FileHelper.Save(FilePath, loans);

        public void Add(Loan loan)
        {
            var loans = GetAll();
            loans.Add(loan);
            SaveAll(loans);
        }
    }
}