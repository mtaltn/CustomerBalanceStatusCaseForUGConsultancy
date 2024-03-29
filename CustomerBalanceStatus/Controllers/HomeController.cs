using CustomerBalanceStatus.Models.Context;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace CustomerBalanceStatus.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new AppDbContext();
        }

        public ActionResult Index()
        {
            var musteriList = _dbContext.MusteriTanims.ToList();
            return View(musteriList);
        }

        [HttpGet]
        public ActionResult FindMaxDebtDate(int musteriId)
        {
            var commandText = "EXEC FindMaxDebtDate @MUSTERI_ID";

            var maxDebtDate = _dbContext.Database.SqlQuery<DateTime?>(
                commandText,
                new SqlParameter("@MUSTERI_ID", musteriId)
            ).FirstOrDefault();

            if (maxDebtDate != null)
            {
                ViewBag.MaxDebtDate = maxDebtDate.ToString();
                ViewBag.Unvan = FindUnvanById(musteriId);
            }
            else
            {
                ViewBag.MaxDebtDate = "Max debt date not found";
            }

            return View();
        }

        public string FindUnvanById(int musteriId)
        {
            var musteri = _dbContext.MusteriTanims.FirstOrDefault(x => x.ID == musteriId);
            return musteri != null ? musteri.UNVAN : "";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
