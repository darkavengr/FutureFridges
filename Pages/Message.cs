using FutureFridgesCW.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FutureFridgesCW.Pages
{
    public class Message
    {
        public readonly AppDataContext _db;
        private readonly UserManager<AppUser> _userManager;

        public Message(AppDataContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public List<Notification> GetMessages()
        {
            List<Notification> messages = new List<Notification>();

            messages = _db.Notifications.ToList();
            return (messages);

        }

        public void SendMessage(string Message, string SendTo, string SentFrom)
        {

            System.Diagnostics.Debug.WriteLine("OnGetSentMessage=" + Message);

            Notification notification = new Notification();

            notification.Message = Message;
            notification.dateAndTimeSent = DateTime.Now;
            notification.sentFrom = SentFrom;
            notification.SentTo = SendTo;

            Guid guid = Guid.NewGuid();

            notification.Id = guid.ToString();

            _db.Notifications.Add(notification);
            _db.SaveChanges();
        }


        public List<Products> GetCloseToExpiringItems()
        {
            List<Products> items = new List<Products>();

            // Get the current date and time
            DateTime currentDate = DateTime.Now;
            if (currentDate.DayOfWeek == DayOfWeek.Monday)
            {
                // Get the items in the fridge that are going to expire in the next 7 days
                items = _db.Products
                    .Where(i => i.expiryDate >= currentDate && i.expiryDate < currentDate.AddDays(7))
                    .ToList();
            }

            return items;
        }

        public void Delete(string Id)
        {
            _db.Remove(_db.Notifications.Find(Id));
            _db.SaveChanges();
        }
        
    }
}
