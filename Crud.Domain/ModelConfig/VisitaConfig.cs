using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.Domain
{
    class VisitaConfig : IEntityTypeConfiguration<VisitaEntity>
    {
        public void Configure(EntityTypeBuilder<VisitaEntity> builder)
        {
            builder.ToTable("Visita", "dbo")
                .HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(p => p.Correo)
                .HasMaxLength(150)
                .IsUnicode(true)
                .IsRequired();
            builder.Property(p => p.Celular)
                .IsRequired();
            builder.Property(p => p.Motivo)
                .IsRequired();
            builder.Property(p => p.Comentario)
                .HasColumnType("varchar(MAX)");

            builder.Seed();
        }
    }
}
