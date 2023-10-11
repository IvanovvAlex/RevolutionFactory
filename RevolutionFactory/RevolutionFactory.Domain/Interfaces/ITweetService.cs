using RevolutionFactory.Common.Models.Tweet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionFactory.Domain.Interfaces
{
    public interface ITweetService
    {
        Task<IEnumerable<string>> GetTweetsWithUrlsFromAPI(string accountName);

        Task<IEnumerable<TweetViewModel>> GetTweetsFromDb(string accountName);
    }
}
