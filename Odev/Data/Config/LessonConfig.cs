using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odev.Models;

namespace Odev.Data.Config
{
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(x => x.ID).IsRequired().UseIdentityColumn();
            builder.HasKey(x=> x.ID);
            builder.HasOne(x => x.School).WithMany(x => x.Lessons).HasForeignKey(x=> x.SchoolID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Lessons).HasForeignKey(x=> x.TeacherId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ClassRoom).WithMany(x => x.Lessons).HasForeignKey(x=> x.ClassRoomId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Students).WithMany(x => x.Lessons);
        }
    }
}
