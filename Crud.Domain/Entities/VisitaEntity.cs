namespace Crud.Domain
{
    public partial class VisitaEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public long Celular { get; set; }
        public MotivoVisita Motivo { get; set; }
        public string Comentario { get; set; }
    }
}
