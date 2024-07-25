using System.ComponentModel.DataAnnotations;

namespace FutureFridgesCW.Models
{
    public class Track
    {
        [Key]
        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int UserName { get; set; }

        public int ProductName { get; set; }

        public DateTime DateTime { get; set;}
    }
}
