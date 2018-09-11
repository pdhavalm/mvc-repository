using BuuCoin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuuCoin.Repository;
using BuuCoin.Helper;

namespace BuuCoin.Controllers
{
    public class HomeController : Controller
    {
        IAdminRepository _IAdminRepository = new AdminRepository(new TestEntities());

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

        [HttpPost]
        public ActionResult Login(Admin model)
        {
            var res = _IAdminRepository.GetAdmin(model.Username, model.Password);
            if (res != null)
            {
                SessionFecade.admin = res;
                return Json(new { aaData = 1 }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { aaData = -1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            SessionFecade.admin = null;
            return RedirectToAction("Index");
        }
    }
}