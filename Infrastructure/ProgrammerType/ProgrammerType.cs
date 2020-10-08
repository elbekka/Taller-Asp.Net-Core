using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ProgrammerType
{
    public class ProgrammerType : IProgrammerType
    {
        private readonly GestorContext _gestorContext;
        public ProgrammerType(GestorContext gestorContext)
        {
            _gestorContext = gestorContext;
        }
        public async Task<(IEnumerable<TipoProgramadores>, string, string)> GetSelectList(CancellationToken cancellationToken)
        {
            var list= _gestorContext.TipoProgramadores.AsEnumerable();

            return (list,nameof(TipoProgramadores.Id),nameof(TipoProgramadores.Nombre)) ;
        }
    }
}
