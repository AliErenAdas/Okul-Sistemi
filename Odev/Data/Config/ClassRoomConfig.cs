using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odev.Models;

namespace Odev.Data.Config
{
    public class ClassRoomConfig : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.Property(x=> x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x=> x.Name).IsUnicode().IsRequired().HasMaxLength(25);
            builder.Property(x => x.Capasity).IsRequired();
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasOne(x => x.School).WithMany(x => x.Classrooms).HasForeignKey(x => x.SchoolId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
