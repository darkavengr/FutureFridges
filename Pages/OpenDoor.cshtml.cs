using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FutureFridgesCW.Pages
{
    public class OpenDoorModel : PageModel
    {
        public string driverpin;

        public void OnGet()
        {
            if (User.IsInRole("Driver"))
            {
                Random random = new Random();

                driverpin = "";

                do
                {
                    driverpin += random.Next() % 9;
                } while (driverpin.Length < 4);

                ViewData["DriverPIN"] = "Your PIN to open the door is " + driverpin;

            }
        }
    }
}
