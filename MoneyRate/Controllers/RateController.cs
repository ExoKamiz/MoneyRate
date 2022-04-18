using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyRate.Data;
using MoneyRate.Models;

namespace MoneyRate.Controllers
{
    public class RateController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RateController(ApplicationDbContext db)
        {
            _db = db;       //даем доступ к базе данных
        }
        public async Task<IActionResult> Index(IEnumerable<Rate> rateList, string searchString)
        {
            rateList = _db.Rate;      //записываем наши Rate в бд и передаем в представления

            var rates = from m in _db.Rate
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                rates = rates.Where(s => s.CountryName!.Contains(searchString));
            }

            return View(await rates.ToListAsync());
        }


    }
}
