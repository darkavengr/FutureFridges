using FutureFridgesCW.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FutureFridgesCW.Models;

namespace FutureFridgesCW.Pages
{

    public class NotificationModel : PageModel
    {
        public List<Notification> Notifications { get; set; }
        public readonly AppDataContext _db;
        private readonly UserManager<AppUser> _userManager;
        private Message Messages;

        public NotificationModel(AppDataContext db,UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            Messages = new Message(_db, _userManager);
        }

        public void OnGet()
        {            
            Notifications = Messages.GetMessages();

            //System.Diagnostics.Debug.WriteLine("NOTIFICATION COUNT="+Notifications.Count);

            if (Notifications.Count == 0) ViewData["EmptyPage"] = "You have no messages";
            
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday) { 
                ViewData["CloseToExpiring"] = GetCloseToExpiringItems();
            }
        }
        private List<Products> GetCloseToExpiringItems() { 
            
            List<Products> closeToExpiring = new List<Products>();

            closeToExpiring = _db.Products.Where(x => x.expiryDate <= DateTime.Now.AddDays(3)).ToList();

            return closeToExpiring; }


        public IActionResult OnGetDelete(string Id)
        {
            Messages.Delete(Id);
            return RedirectToPage("/Notification");
        }

    }
}
