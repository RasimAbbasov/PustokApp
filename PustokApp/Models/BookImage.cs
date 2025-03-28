using System.ComponentModel.DataAnnotations;

namespace PustokApp.Models
{
    public class BookImage:BaseEntity
    {
        [Required]
        public string ImgName { get; set; }
        public bool? Status { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
