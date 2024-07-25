using FutureFridgesCW.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FutureFridgesCW.Pages
{
    //[Authorize(Roles = "Headchef,Chef,Driver")]
    public class InsertModel : PageModel
    {
        private readonly AppDataContext _db;
        private readonly UserManager<AppUser> _userManager;
        public bool queryStringChecker { get; set; }
        public string button { get; set; }

        [BindProperty]
        public Products productGoingIntoFridge { get; set; }
        public bool Save { get; set; }
        public bool Update { get; set; }
        public Order order { get; set; }


        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public InsertModel(AppDataContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public void OnGet()
        {
            productGoingIntoFridge = _db.Products.Find(Id);
            //order = _db.Order.FirstOrDefault(o => o.ProductName == productGoingIntoFridge.ProductName && o.quantity == productGoingIntoFridge.quantity);
        }

        //public IActionResult OnPost()
        //{
        //    productGoingIntoFridge.userWhoInsertedProduct = _userManager.GetUserAsync(User).Result.Email;
        //    _db.Products.Add(productGoingIntoFridge);
        //    _db.SaveChanges();
        //    return RedirectToPage("/Remove");
        //}

        public IActionResult OnPost()
        {
            productGoingIntoFridge.userWhoInsertedProduct = _userManager.GetUserAsync(User).Result.Email;
            // Check if the product going into the fridge matches the items ordered
            var orderCheck = _db.Order.FirstOrDefault(o => o.ProductName == productGoingIntoFridge.ProductName && o.quantity == productGoingIntoFridge.quantity);
           
            if (orderCheck == null)
            {
                ModelState.AddModelError("productGoingIntoFridge.ProductName", "The product name and quantity do not match the items ordered");
                return Page();

            }
            // Update the order status if the product name and quantity match the items ordered
            orderCheck.Status = "Delivered";
            _db.Order.Update(orderCheck);
            _db.Products.Add(productGoingIntoFridge);
            _db.SaveChanges();
            return RedirectToPage("/Remove");
        }

        //public IActionResult OnPostUpdate()
        //{
        //    productGoingIntoFridge.userWhoInsertedProduct = _userManager.GetUserAsync(User).Result.Email;
        //    _db.Products.Update(productGoingIntoFridge);
        //    _db.SaveChanges();
        //    return RedirectToPage("/Remove");
        //}

    }


}
