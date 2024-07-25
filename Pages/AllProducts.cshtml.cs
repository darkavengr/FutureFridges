using FutureFridgesCW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FutureFridgesCW.Pages
{
    public class AllProductsModel : PageModel
    {
        public List<Products> Products { get; set; }

        private readonly AppDataContext _db;

        public AllProductsModel(AppDataContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Products = _db.Products.ToList();
        }

        public IActionResult OnGetDelete(int Id)
        {
            _db.Remove(_db.Products.Find(Id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult OnPostPrintExpiredProducts()
        {
            var expiredProducts = _db.Products.Where(p => p.expiryDate < DateTime.Now).ToList();
            return new JsonResult(expiredProducts);
        }
    }
}

