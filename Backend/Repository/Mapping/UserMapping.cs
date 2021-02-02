using Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Repository.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Photo).IsRequired().HasMaxLength(200);

            builder.HasMany(x => x.FavoriteMusics).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
        }
    }
}