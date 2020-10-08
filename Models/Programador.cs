
namespace Models
{
    public class Programador
    {
        public int Id { get; set; }
        public int TipoProgramadorId { get; set; }
        public TipoProgramadores TipoProgramador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string DNI_NIE { get; set; }
        public Programador()
        {

        }

    }
}
