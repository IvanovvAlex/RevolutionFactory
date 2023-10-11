using Microsoft.EntityFrameworkCore;
using RevolutionFactory.Data.Entities;
using RevolutionFactory.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RevolutionFactory.Data.Repositories
{
    public class TweetRepository : Repository<Tweet>, ITweetRepository
    {
        private RevolutionFactoryDbContext RevolutionFactoryDbContext => _context as RevolutionFactoryDbContext;

        public TweetRepository(RevolutionFactoryDbContext context) : base(context)
        {
        }

        public async Task<Tweet> Update(Tweet tweet)
        {
            string tweetId = tweet.Id;

            Tweet editeTweet = await RevolutionFactoryDbContext.Tweets.FirstOrDefaultAsync(x => x.Id == tweetId);

            if (editeTweet == null)
            {
                return null;
            }

            editeTweet.TweetContent = tweet.TweetContent;
            editeTweet.URL = tweet.URL;
            editeTweet.Timestamp = tweet.Timestamp;


            return editeTweet;
        }
        public override async ValueTask<Tweet> GetByIdAsync(string id)
        {
            return await RevolutionFactoryDbContext.Tweets
            .FirstOrDefaultAsync(o => o.Id == id);
        }

        public override async Task<IEnumerable<Tweet>> GetAsync()
        {
            return await RevolutionFactoryDbContext.Tweets
                .ToListAsync();
        }
    }
}