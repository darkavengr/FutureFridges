using FutureFridgesCW.Models;
using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FutureFridgesCW.Pages
{

    public class RemoveModel : PageModel
    {
        public List<Products> Products { get; set; }
        private readonly AppDataContext _db;
        private readonly UserManager<AppUser> _userManager;

        public RemoveModel(AppDataContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public void OnGet()
        {
            Products = _db.Products.ToList();
        }
        
        public IActionResult OnGetDelete(int Id)
        {
            System.Diagnostics.Debug.WriteLine("REMOVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");

            Message message = new Message(_db, _userManager);
            var user = _userManager.GetUserAsync(User).Result.UserName;

            System.Diagnostics.Debug.WriteLine("Id=" + Id);

            var removeproduct = _db.Products.FirstOrDefault(o => o.ProductId == Id);
                       
            if (removeproduct != null)  {
               _db.Remove(_db.Products.Find(Id));
               _db.SaveChanges();

               message.SendMessage("Product " + removeproduct.ProductName + "(" + removeproduct.ProductId + " was removed", user, "System");
             }
            return RedirectToAction("/Remove"); 
        }

     /*   public IActionResult OnGetIncrementQuantity(int Id)
        {
        
            var IncrementProductQuantity = _db.Products.FirstOrDefault(o => o.ProductId == Id);

            if(IncrementProductQuantity != null) {
                IncrementProductQuantity.quantity++;

                _db.Products.Update(IncrementProductQuantity);

                _db.SaveChanges();
            }

            return RedirectToAction("/Remove");
        } */
    }
}  

