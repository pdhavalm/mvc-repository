using BuuCoin.Helper;
using BuuCoin.Model;
using BuuCoin.Repository;
using System.Linq;
using System.Web.Mvc;

namespace BuuCoin.Controllers
{
    [SessionTimeoutAttribute]
    public class UserController : Controller
    {
        ICategoryRepository _ICategoryRepository = new CategoryRepository(new TestEntities());

        // GET: User
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCategory(JqueryDataTableParamModel param)
        {
            var _list = _ICategoryRepository.GetAll();
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = _list.Count(),
                iTotalDisplayRecords = _list.Count(),
                aaData = _list
            },JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertUpdate(Category model)
        {
            if (model.Id == 0)
            {
                var res = _ICategoryRepository.Insert(model);
                return Json(new
                {
                    aaData = res
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _ICategoryRepository.Update(model);
                return Json(new
                {
                    aaData = 1
                }, JsonRequestBehavior.AllowGet);
            }
           
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _ICategoryRepository.Delete(id);
            return Json(new
            {
                aaData = 1
            }, JsonRequestBehavior.AllowGet);
        }

    }
}