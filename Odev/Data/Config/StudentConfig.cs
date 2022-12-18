using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odev.Models;

namespace Odev.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(15);
            

            builder.HasOne(x => x.School).WithMany(x => x.Students).HasForeignKey(x => x.SchoolId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Lessons).WithMany(x => x.Students);
        }
    }
}
