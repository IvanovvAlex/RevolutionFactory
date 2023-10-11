using RevolutionFactory.Data.Interfaces;
using RevolutionFactory.Data.Interfaces.Repositories;
using RevolutionFactory.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionFactory.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RevolutionFactoryDbContext _context;

        private readonly ITweetRepository _tweetRepository;

        public UnitOfWork(RevolutionFactoryDbContext context,
            ITweetRepository tweetRepository)
        {
            _context = context;
            _tweetRepository = tweetRepository;
        }

        public ITweetRepository Tweets => _tweetRepository ?? new TweetRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}