using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Data.Models
{
    [Comment ("Collection from products")]
    public class Product
    {
        [Key]
        [Comment("ProductIdentifier")]
        public int Id { get; set; }

        [Required]
        [StringLength (100)]
        public string Name { get; set; } = string.Empty;
        public List<ProductNote> ProductNotes { get; set; } = new List<ProductNote> ();
    }
}
