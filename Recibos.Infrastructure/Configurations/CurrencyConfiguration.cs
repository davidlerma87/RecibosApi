using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recibos.Core.Entities;

namespace Recibos.Infrastructure.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Monedas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Acronym)
                .IsRequired()
                .HasColumnName("Acronimo")
                .HasMaxLength(3)
                .IsUnicode(false);
        }
    }
}
