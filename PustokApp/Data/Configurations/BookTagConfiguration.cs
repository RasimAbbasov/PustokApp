using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PustokApp.Models;

namespace PustokApp.Data.Configurations
{
    public class BookTagConfiguration : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {
            builder.HasKey(x => new { x.BookId, x.TagId });
        }
    }
}
