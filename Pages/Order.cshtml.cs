using FutureFridgesCW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FutureFridgesCW.Pages
{
    public class OrderModel : PageModel
    {
        public int Id { get; set; }
        public List<Order> Order { get; set; }

        private readonly AppDataContext _db;

        public OrderModel(AppDataContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Order = _db.Order.ToList();

        }


        public IActionResult OnGetDelete(int Id)
        {
            _db.Remove(_db.Order.Find(Id));
            _db.SaveChanges();
            return RedirectToAction("/Order");
        }

        public IActionResult OnGetOrderItem()
        {
            return RedirectToPage("/OrderItem");


        }

    }
}
