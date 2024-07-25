using FutureFridgesCW.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using System.Data.Entity;

namespace FutureFridgesCW.Pages
{
    public class TrackModel : PageModel
    {
        private readonly FutureFridgesCW.Models.AppDataContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        public List<AppUser> UserList { get; set; }
        public List<Products> ProductList { get; set; }

        public readonly AppDataContext _db;
        private readonly UserManager<AppUser> _userManager;

       
        public TrackModel(FutureFridgesCW.Models.AppDataContext context, AppDataContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;

            UserList = _userManager.Users.ToList();
            ProductList = _db.Products.ToList();

        }
        public void OnGet()
        { 
        }
    }
}

