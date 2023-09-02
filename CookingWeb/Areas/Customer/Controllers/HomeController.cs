using Cooking.DataAccess.Repository.IRepository;
using Cooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CookingWeb.Area.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Recipie> recipieList = _unitOfWork.Recipie.GetAll(includeProperties: "Category");
            return View(recipieList);
        }

        public IActionResult Details(int recipieid)
        {
            Recipie recipie = _unitOfWork.Recipie.Get(u=>u.Id== recipieid, includeProperties: "Category");
            return View(recipie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}