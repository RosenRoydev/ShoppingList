using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Data.Models
{
    [Comment("Product Notes")]
    public class ProductNote
    {
        [Comment("Product Note Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Content of note")]
        [StringLength(1500)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Product Identifier")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}