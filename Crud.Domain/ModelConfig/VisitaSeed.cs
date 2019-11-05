using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.Domain
{
    static class VisitaSeed
    {
        public static void Seed(this EntityTypeBuilder<VisitaEntity> builder)
        {
            builder.HasData(
                new VisitaEntity
                {
                    Id = 1,
                    Nombre = "Cristian Bonilla",
                    Correo = "cristiancamilo10_95@outlook.com",
                    Celular = 3163534451,
                    Motivo = MotivoVisita.Venta
                },
                new VisitaEntity
                {
                    Id = 2,
                    Nombre = "Jessica Gutierrez",
                    Correo = "jessea_19av@gmail.com",
                    Celular = 3201198827,
                    Motivo = MotivoVisita.Compra,
                    Comentario = "Productos exclusivos de fragancia VIP Carolina Herrera"
                },
                new VisitaEntity
                {
                    Id = 3,
                    Nombre = "Luz Andrea Ramos",
                    Correo = "luz.andre881@gmail.com",
                    Celular = 3192550012,
                    Motivo = MotivoVisita.Alquiler
                },
                new VisitaEntity
                {
                    Id = 4,
                    Nombre = "Sandra Lozano",
                    Correo = "sandrylozano89@hotmail.com",
                    Celular = 3227179901,
                    Motivo = MotivoVisita.Compra
                },
                new VisitaEntity
                {
                    Id = 5,
                    Nombre = "Felipe Santiago Giraldo",
                    Correo = "santi87.giraldo@gmail.com",
                    Celular = 31477810911,
                    Motivo = MotivoVisita.Venta,
                    Comentario = "Ropa de gran calidad y al mejor costo"
                });
        }
    }
}
