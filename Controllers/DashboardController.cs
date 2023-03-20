using Microsoft.AspNetCore.Mvc;
using my_expenses.Data;
using my_expenses.Models;

namespace my_expenses.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDataContext _context;

        public DashboardController(AppDataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions
                .Include(x => x.Category)
                .Where(y => y.Date>= StartDate && y.Date<= EndDate)
                .ToListAsync();

            int TotalIncome = SelectedTransactions
                .Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("0");

            int TotalExpense = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("0");

            int Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = Balance.ToString("0");

            return View();
        }
    }
}
