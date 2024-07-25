using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FutureFridgesCW.Models;
using Microsoft.AspNetCore.Identity;
using System;


namespace FutureFridgesCW.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        public readonly AppDataContext _db;
        private readonly UserManager<AppUser> _userManager;
        public List<AppUser> Users { get; set; }

        int NumberOfDaysProductExpires = 3;
        int ReorderLimit = 5;

        public IndexModel(ILogger<IndexModel> logger, AppDataContext db, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public void OnGet()
        {
            Message message = new Message(_db, _userManager);
            var user = _userManager.GetUserAsync(User).Result.UserName;
            string driverpin;
            
            // message.SendMessage("Test message", user, "Nobody");

            if (User.IsInRole("Headchef"))
            {
                DateTime CheckDay= new DateTime();
                CheckDay = DateTime.Now;
                    
              //  System.Diagnostics.Debug.WriteLine("day=" + CheckDay.DayOfWeek + " " + DayOfWeek.Monday);

                if (CheckDay.DayOfWeek == DayOfWeek.Monday) {

                    List<Products> products = new List<Products>();
                    products = _db.Products.ToList();

                    DateTime datetime = new DateTime();
                    DateTime ptime = new DateTime();

                    datetime.AddDays(NumberOfDaysProductExpires);

                    foreach (var p in products)
                    {

                        if (DateTime.Compare(ptime, datetime) >= 0)
                        {
                            message.SendMessage("Product " + p.ProductName + "(" + p.ProductId + ") will expire in " + NumberOfDaysProductExpires + " days", user, "System");
                        }

                        if (p.quantity <= ReorderLimit)
                        {
                            message.SendMessage("Product " + p.ProductName + "(" + p.ProductId + ") has only  " + ReorderLimit + " items. Re-order now.", user, "System");
                        }

                    }
                }
            }

            if (User.IsInRole("Driver"))
            {
                Random random = new Random();

                driverpin = "";

                do
                {
                    driverpin += random.Next();
                } while (driverpin.Length < 4);

                ViewData["DriverPIN"] = "Your PIN to open the door is " + driverpin;

            }

            

        }
    }
}