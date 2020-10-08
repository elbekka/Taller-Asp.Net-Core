using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ProgrammerType
{
    public interface IProgrammerType
    {
        Task<(IEnumerable<TipoProgramadores>,string,string)> GetSelectList(CancellationToken cancellationToken);
    }
}
