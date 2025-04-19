namespace PustokApp.ViewModel
{
    public class BookModalVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public bool InStock { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int Rate { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
        public List<string> BookImages { get; set; }
        public List<string> BookTags { get; set; }
    }
}
