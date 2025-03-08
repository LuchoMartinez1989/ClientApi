using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistense.Configuration
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        /// <summary>
        /// configura la construccion de la tabla
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedBy).HasMaxLength(15);
            builder.Property(c => c.LastModifiedBy).HasMaxLength(15);
            builder.Property(c => c.IdenticacionCode).HasMaxLength(15);
            builder.Property(c => c.IdTypeIdentification).HasMaxLength(1);
            builder.Property(c => c.BornDate).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(40).IsRequired();
            builder.Property(c => c.Lastnames).HasMaxLength(40).IsRequired();
            builder.Property(c => c.Mail).HasMaxLength(40).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(40);
            builder.Property(c => c.Phone).HasMaxLength(15);
            // add new property
            builder.Property(c => c.Gender).HasMaxLength(20);

        }
    }
}
