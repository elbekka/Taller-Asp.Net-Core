using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class TipoProgramadores
    {
        public static readonly TipoProgramadores BackEnd = new TipoProgramadores(1, "Back-End");
        public static readonly TipoProgramadores FrontEnd = new TipoProgramadores(2, "Front-End");
        public static readonly TipoProgramadores FullStack = new TipoProgramadores(3, "Full-Stack");
        public int Id { get; set; }
        public string Nombre { get; set; }

        public TipoProgramadores(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public static TipoProgramadores GetById(int id)
        {
            var type = GetAll().FirstOrDefault(type => type.Id == id);
            if(type  == null)
            {
                throw new ArgumentException("Tipo de programador no existe");
            }
            return type;
        }

        public static List<TipoProgramadores> GetAll()
        {
            return new List<TipoProgramadores>()
            {
                BackEnd,
                FrontEnd,
                FullStack
            };
        }
    }
}
