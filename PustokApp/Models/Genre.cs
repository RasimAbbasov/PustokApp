using System.ComponentModel.DataAnnotations;

namespace PustokApp.Models
{
    public class Genre:BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
