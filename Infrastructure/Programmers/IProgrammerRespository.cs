using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Programmers
{
    public interface IProgrammerRespository
    {
        Task<List<Programador>> GetAllProgrammers(CancellationToken cancellation);
        Task<Programador> GetProgrammerById(int? idProgrammer, CancellationToken cancellation);
    }
}
