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

        //GET 
        public async Task<IActionResult> Index(string searchString)
        {
            //rateList = _db.Rate;      //записываем наши Rate в бд и передаем в представления

            var rates = from m in _db.Rate          //создает запрос LINQ и выводит
                        select m;

            if (!String.IsNullOrEmpty(searchString))        //если содержит строку, то меняется запрос
            {
                rates = rates.Where(s => s.CountryName!.Contains(searchString));
            }

            return View(await rates.ToListAsync());
        }

        //POST
        [HttpPost]
        public string Index(string searchString, bool notUsed)  //Параметр notUsed используется для создания перегрузки Index метода
        {
            return "From [HttpPost]Index: filter on " + searchString;   //делая запрос, мы переходим на новую страницу с 
                                                                        //отфильтрованными данными, а не перезагружаем страницу
        }

    }
}
