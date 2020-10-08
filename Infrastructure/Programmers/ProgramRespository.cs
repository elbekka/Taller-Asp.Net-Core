using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Programmers
{
    public class ProgramRespository : IProgrammerRespository
    {
        private readonly GestorContext _gestorContext;
        public ProgramRespository(GestorContext gestorContext)
        {
            _gestorContext = gestorContext;
        }
        public async Task<List<Programador>> GetAllProgrammers(CancellationToken cancellationToken)
        {
            return await _gestorContext.Programadores.ToListAsync(cancellationToken);
        }

        public async Task<Programador> GetProgrammerById(int? idProgrammer, CancellationToken cancellation)
        {
            if (!idProgrammer.HasValue) return null;
            return await _gestorContext.Programadores.Include(item => item.TipoProgramador).FirstOrDefaultAsync(programmer => programmer.Id == idProgrammer.Value, cancellation);
        }
    }
}
