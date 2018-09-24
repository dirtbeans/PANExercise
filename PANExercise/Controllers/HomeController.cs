using PANExercise.DAL;
using PANExercise.Models;
//added above to use GamesDAL
using System;
using System.Collections.Generic;
using System.Configuration;
//added to use Configuration Manager
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PANExercise.Controllers
{
    public class HomeController : Controller
    {

        private readonly GamesDAL dal;

        public HomeController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Games"].ConnectionString;
            dal = new GamesDAL(connectionString);
        }

        public ActionResult Index()
        {
            return View();
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

        public ActionResult ListOfGames()
        {
            List<Game> games = dal.GetAllGames();

            return View("ListOfGames", games);

        }

        public ActionResult SingleGame(int id)
        {

            Game game = dal.GetOneGame(id);
            return View("SingleGame", game);
        }

        public ActionResult AddGame()
        {
            return View("AddGame");
        }

        [HttpPost]
        public ActionResult AddGameResult(Game game)
        {
            
                dal.AddGame(game);
                return RedirectToAction("Index");
        }

        public ActionResult EditGame(int id)
        {
           
                Game game = dal.GetOneGame(id);
                return View("EditGame", game);
           
        }

        [HttpPost]
        public ActionResult EditGameResult(Game game)
        {
           
            dal.EditTheGame(game);
            return RedirectToAction("Index");
        }



    }
}