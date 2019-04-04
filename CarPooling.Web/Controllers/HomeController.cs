using Microsoft.AspNetCore.Mvc;
using CarPooling.DataAcces.Repository;
using CarPooling.Domain;
namespace CarPooling.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //GenericRepository<User> repo = new GenericRepository<User>();
            return View();
        }
        public IActionResult addride()
        {
            return View("~/Views/Home/add-ride.cshtml");
        }
        public IActionResult events()
        {
            return View("~/Views/Home/events.cshtml");
        }
        public IActionResult blog()
        {
            return View("~/Views/Home/blog.cshtml");
        }
        public IActionResult contactpage()
        {
            return View("~/Views/Home/contact-page.cshtml");
        }
        public IActionResult page()
        {
            return View("~/Views/Home/page.cshtml");
        }
        public IActionResult rides()
        {
            return View("~/Views/Home/rides.cshtml");
        }
        public IActionResult singlearticle()
        {
            return View("~/Views/Home/single-article.cshtml");
        }
        public IActionResult singlepost()
        {
            return View("~/Views/Home/single-post.cshtml");
        }
    }
}
