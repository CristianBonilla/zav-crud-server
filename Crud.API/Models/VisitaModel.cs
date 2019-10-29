using Crud.Domain;

namespace Crud.API
{
    public class VisitaModel
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public long Celular { get; set; }
        public MotivoVisita Motivo { get; set; }
        public string Comentario { get; set; }
    }
}
