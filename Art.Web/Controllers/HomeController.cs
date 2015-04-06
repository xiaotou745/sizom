using AC.SpringUtils;
using Art.Common.Services;
using Art.Service.User;
using Art.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Services
        private IUsersService usersService;

        protected IUsersService UsersService
        {
            get { return usersService ?? ServiceLocator.GetService<IUsersService>(); }
        }
        #endregion

        public ActionResult Index()
        {
            ViewBag.Message = "首页";

            IndexModel indexModel = new IndexModel();
            var homeIndexServices = ServiceLocator.GetService<HomeIndexServices>("homeIndexServices");
            indexModel.HotArtists = homeIndexServices.GetHotArtists();
            indexModel.HotWorks = homeIndexServices.GetHotWorks();
            indexModel.NewsLasted = homeIndexServices.GetLastedNews();
            indexModel.RecentRegistedArtists = homeIndexServices.GetRecentRegistedArtist();
            indexModel.TopicLasted = homeIndexServices.GetLastedTopic();

            return View(indexModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
