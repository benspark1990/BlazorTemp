using System.ComponentModel.DataAnnotations.Schema;

namespace YumBlazor.Data
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}
