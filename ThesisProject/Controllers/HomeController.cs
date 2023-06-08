using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThesisProject.Models;
using Npgsql;
using ThesisProject.Context;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;



namespace ThesisProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SongService _songService;

        public HomeController(ILogger<HomeController> logger, SongService songService)
        {
            _logger = logger;
            _songService = songService; 
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
            var model = _songService.getTopFive(username);
            ViewBag.mymodel=model;
            LoginModel login = null;
            var tuple = (model, login);
            return View("Homepage",tuple);
        }
        public IActionResult Login()
        {
            return View();
        }

           
         public IActionResult Moods(string username) {

            ViewBag.username = username;
            return View();

           
        }
        public IActionResult Playlists(string mood,string username) {

            var SongModel = _songService.getSongList(username,mood);
            ViewBag.mood = mood;
            ViewBag.username = username;
            return View("Playlists",SongModel);           
           
        }

        public IActionResult Favorites(string username) {
            ViewBag.username=username;
            var model = _songService.getLikedSongs(username);
            return View("Favorites",model);

        }

        [HttpPost]
        public IActionResult LikeUnlike(string username,string mood,int songid,bool isLiked )
        {
            ViewBag.username = username;
            ViewBag.mood = mood;
            ViewBag.songid = songid;
            ViewBag.isLiked = isLiked;
            var SongModel = _songService.Like(username, mood,songid,isLiked);
            
            return View("Playlists",SongModel);
        }

        [HttpPost]
        public IActionResult Unlike(string username,string mood,int songid,bool isLiked )
        {
            ViewBag.username = username;
            ViewBag.mood = mood;
            ViewBag.songid = songid;
            ViewBag.isLiked = isLiked;
            var SongModel = _songService.UnLike(username, mood,songid,isLiked);            
            return View("Favorites",SongModel);
        }

        [HttpPost]
        public IActionResult HearingCounter(string username,int songid, string mood) 
        { 
            ViewBag.username = username;
            ViewBag.songid=songid;
            _songService.Counter(username, songid);
            var SongModel = _songService.getSongList(username, mood);
            return Json( SongModel);
            
        }


        [HttpPost]
        public IActionResult LikedHearingCounter(string username, int songid)
        {
            ViewBag.username = username;
            ViewBag.songid = songid;
            _songService.Counter(username, songid);
            var SongModel = _songService.getLikedSongs(username);
            return Json(SongModel);

        }


        public IActionResult Profile(string username) {

            ViewBag.username = username;
            var profileinfo = _songService.getProfileInfo(username);
            return View("Profile",profileinfo);
           
        }

        [HttpPost]
        public ActionResult Upload(IFormFile file,string username)
        {
            ViewBag.username = username;
            if (file != null) {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resources", file.FileName);
                using (var filestram = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(filestram);
                }
                _songService.SetProfilePicture(username, "/Resources/" + file.FileName);
                var profileinfo = _songService.getProfileInfo(username);
                return View("Profile", profileinfo);

            }
            else
            {
                var profileinfo = _songService.getProfileInfo(username);                            
                return View("Profile",profileinfo);
            }
            
        }
        public IActionResult Registration()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Registration(RegistrationModel registration)
        {
            if (ModelState.IsValid)
            {
                _songService.Registration(registration);
                return View("Login");

            }
            else { return View("Registration"); }
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
                    var songModels=_songService.getTopFive(username);
                    var model = (songModels,loginModel);

                    return View("~/Views/Home/Homepage.cshtml", model);
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