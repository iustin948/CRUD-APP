using APP.Data;
using APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;            
        }
        public IActionResult Index()
        {
            var objProductList = _db.Products.ToList();
            return View(objProductList);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Product prodFromDb = _db.Products.Find(id);
            if(prodFromDb == null)
            {
                return NotFound();
            }
            return View(prodFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                Console.WriteLine("aici a fost");
                return NotFound();
            }
            Product prodFromDb = _db.Products.Find(id);
            if (prodFromDb == null)
            {
                return NotFound();
            }
            _db.Remove(prodFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
