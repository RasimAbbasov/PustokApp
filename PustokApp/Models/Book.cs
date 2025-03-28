using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokApp.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public bool InStock { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercentage { get; set; }
        public int Rate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<BookImage> BookImages { get; set; }
        public List<BookTag> BookTags { get; set; }
    }
}
