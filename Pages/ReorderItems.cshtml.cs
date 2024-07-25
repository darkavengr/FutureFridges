using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FutureFridgesCW.Models;

namespace FutureFridgesCW.Pages
{
    public class ReorderItemsModel : PageModel
    {
        private readonly AppDataContext _db;         
        [BindProperty]         
        public Order CreateOrder { get; set; }

        public List<Supplier> Suppliers { get; set; }

        

        public List<Products> Products { get; set; }
        public ReorderItemsModel(AppDataContext db)         
        {             
            _db = db;         
        }         
    //    public void OnGet()         
    //    {             
    //        Suppliers = _db.Supplier.ToList();             
    //        Products = _db.Products.ToList();
    //        CreateOrder = new Orders();
    //        CreateOrder.OrderItems = new List<OrderListItems>();         
    //    }         
    //    public IActionResult OnPost()         
    //    {             
    //        CreateOrder.OrderDate = DateTime.Now;
    //        CreateOrder.Status = "Started";
    //        _db.Orders.Add(CreateOrder);             
    //        _db.SaveChanges();                         
    //        foreach (var item in CreateOrder.OrderItems)             
    //        {                
                
    //            var OrderItems = new OrderListItems                 
    //            {
    //                //OrderID = Orders.OrderID,
    //                //SupplierName = item.SupplierName,
    //                ProductName = item.ProductName,
    //                quantity = item.quantity
    //            }; 

    //            _db.OrderItems.Add(OrderItems);
    //}             
    //        _db.SaveChanges();             
    //        return RedirectToPage("/Order");         
    //    }
    }
}
