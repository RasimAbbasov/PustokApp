using System.ComponentModel.DataAnnotations;

namespace PustokApp.Models
{
    public class Author:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
