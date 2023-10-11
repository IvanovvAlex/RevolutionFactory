using RevolutionFactory.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionFactory.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
      
        ITweetRepository Tweets { get; }
        Task<int> CommitAsync();
    }
}
