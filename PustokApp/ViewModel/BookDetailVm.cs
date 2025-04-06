using PustokApp.Models;

namespace PustokApp.ViewModel
{
    public class BookDetailVm
    {
        public Book Book { get; set; }
        public List<Book> RelatedBooks { get; set; }
    }
}
