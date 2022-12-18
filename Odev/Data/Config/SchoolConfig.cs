using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odev.Models;

namespace Odev.Data.Config
{
    public class SchoolConfig : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Classrooms).WithOne(x => x.School).HasForeignKey(x => x.SchoolId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Students).WithOne(x => x.School).HasForeignKey(x => x.SchoolId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Teachers).WithOne(x => x.School).HasForeignKey(x => x.SchoolID).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Lessons).WithOne(x => x.School).HasForeignKey(x => x.SchoolID).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
