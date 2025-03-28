namespace PustokApp.Models
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
