using FutureFridgesCW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FutureFridgesCW.Pages
{
    public class OrderItemModel : PageModel
    {
        [BindProperty]
        public Order CreateOrder { get; set; }
        public List<Order> ItemList { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        private readonly AppDataContext _db;
        public OrderItemModel(AppDataContext db)
        {
            _db = db;
            CreateOrder = new Order();
            ItemList = new List<Order>();
        }

        public void OnGet()
        {
            CreateOrder = _db.Order.Find(Id);

        }

        public IActionResult OnGetBack()
        {
            return RedirectToPage("/Order");
        }

        public void OnPost()
        {
            System.Diagnostics.Debug.WriteLine("Add product");
            System.Diagnostics.Debug.WriteLine(CreateOrder.SupplierName);

            CreateOrder.Status = "Waiting";

            _db.Order.Update(CreateOrder);
            _db.SaveChanges();

            ViewData["SubmitInformation"] = "Product " + CreateOrder.OrderID + " was submitted. Add more products or return to previous page";
        }
    }
}