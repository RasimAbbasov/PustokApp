using System.ComponentModel.DataAnnotations;

namespace PustokApp.Models
{
    public class Genre:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
