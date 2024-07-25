using System.ComponentModel.DataAnnotations;

namespace FutureFridgesCW.Models
{
    public class TrackProducts
    {
        [Key]
        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int UserName { get; set; }

        public int ProductName { get; set; }

        public DateTime DateTime { get; set; }

        public virtual AppUser User { get; set; }

        public virtual Products Products { get; set; }

    }
}
