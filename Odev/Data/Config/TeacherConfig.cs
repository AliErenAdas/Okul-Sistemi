using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odev.Models;

namespace Odev.Data.Config
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x=> x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Courses).WithMany(x => x.Teachers);
            builder.HasMany(x => x.Lessons).WithOne(x => x.Teacher).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.School).WithMany(x => x.Teachers).HasForeignKey(x => x.SchoolID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
