using Microsoft.EntityFrameworkCore.Internal;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public static class SeedInMemory
    {
        public static void SeedSampleInMemory(GestorContext context)
        {
            if (!context.Programadores.Any())
            {
                context.Programadores.Add(
                    new Programador() { Nombre = "Juan" , TipoProgramadorId = 1,Apellido = "Ramirez" , Edad = 31,DNI_NIE = "50486254F"}
                    );
                context.TipoProgramadores.AddRange(TipoProgramadores.GetAll());
                context.SaveChanges();
            }
        }
    }
}
