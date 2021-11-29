using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
        {
            // Configuração para criar uma tabela User
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(u => u.Email)
                .HasMaxLength(100);
        }
    }
}
