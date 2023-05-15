using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThesisProject.Models;
using Npgsql;
using ThesisProject.Context;

namespace ThesisProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Homepage(string username) {
            ViewBag.username = username;

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

           
         public IActionResult Moods(string username) {

            ViewBag.username = username;

            return View();

           
        }
        
        public IActionResult Favorites(string username) {

            ViewBag.username = username;

            return View();
           
        }
        public IActionResult Profile(string username) {

            ViewBag.username = username;

            return View();
           
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(LoginModel loginModel) {

            string username = loginModel.username;
            var password = loginModel.password;

            NpgsqlConnection connection = Database.Database.Connection();
            DatabaseContext databaseContext = new DatabaseContext();
            NpgsqlDataReader output = Database.Database.ExecuteQuery(string.Format("select *" +
                " from users where username ='{0}'",username), connection);
            if (output.Read())
            {
                string correct_pass = output.GetString(1);
                connection.Close();
                if (correct_pass == password)
                {
                    ViewBag.Username = loginModel.username;
                    return View("~/Views/Home/Homepage.cshtml", loginModel);
                }
            }
            loginModel.isLoginConfirmed = false;
            return View("Login", loginModel);

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}