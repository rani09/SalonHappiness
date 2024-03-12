using SalonHappiness.Models;
using System.Linq;
using System.Web.Mvc;

namespace SalonHappiness.Controllers
{
    
    [Authorize(Roles = "User, Administrator")]
    public class AdminController : Controller
    {
        private SalonDbContext db = new SalonDbContext();
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult _User()
        {
            return PartialView(db.Users.ToList());
        }
    }
}