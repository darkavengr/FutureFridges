using System.ComponentModel.DataAnnotations;

namespace FutureFridgesCW.Models
{
    public class Notification
    {
        [Key]
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime dateAndTimeSent { get; set; }
        public string sentFrom { get; set; }
        public string SentTo { get; set; }

    }
}
