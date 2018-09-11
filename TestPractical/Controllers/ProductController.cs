using BuuCoin.Helper;
using BuuCoin.Model;
using BuuCoin.Repository;
using System;
using System.Linq;
using System.Web.Mvc;


namespace BuuCoin.Controllers
{
    [SessionTimeoutAttribute]
    public class ProductController : Controller
    {
        IProductRepository _IProductRepository = new ProductRepository(new TestEntities());
        ICategoryRepository _ICategoryRepository = new CategoryRepository(new TestEntities());

        // GET: Product
        public ActionResult Index()
        {
            ViewBag.Category = _ICategoryRepository.GetAll();

            return View();
        }

        [HttpPost]
        public ActionResult GetProduct(JqueryDataTableParamModel param)
        {

            var _list = _IProductRepository.GetAll();
            var result = _list.Select(s => new ProductViewModel
            {
                Id = s.Id,
                CategoryId = s.CategoryId,
                Category = _ICategoryRepository.GetById(s.CategoryId).Name,
                Name = s.Name,
                Description = s.Description,
                Price = (decimal)s.Price,
                CreatedDate = s.CreatedDate.Value.ToString("dd-MM-yyyy h:mm tt")
            });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = _list.Count(),
                iTotalDisplayRecords = _list.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertUpdate(Product model)
        {
            if (model.Id == 0)
            {
                model.CreatedDate = DateTime.Now;
                var res = _IProductRepository.Insert(model);
                return Json(new
                {
                    aaData = res
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _IProductRepository.Update(model);
                return Json(new
                {
                    aaData = 1
                }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _IProductRepository.Delete(id);
            return Json(new
            {
                aaData = 1
            }, JsonRequestBehavior.AllowGet);
        }

    }
}