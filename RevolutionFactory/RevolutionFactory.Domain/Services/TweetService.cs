using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RevolutionFactory.Common.Models.Tweet;
using RevolutionFactory.Data.Entities;
using RevolutionFactory.Data.Interfaces;
using RevolutionFactory.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Client;
using Tweetinvi.Models;
using Tweetinvi.Parameters.V2;

namespace RevolutionFactory.Domain.Services
{
    public class TweetService : ITweetService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public TweetService(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TweetViewModel>> GetTweetsFromDb(string accountName)
        {
            IEnumerable<Tweet> tweets = await _unitOfWork.Tweets.GetAsync();
            IEnumerable<TweetViewModel> tweetViewModels = tweets.Select(item => new TweetViewModel
            {
                Id = item.Id,
                TweetId = item.TweetId,
                Content = item.TweetContent,
                Timestamp = item.Timestamp,
                URL = item.URL,
            }).ToList();

            return tweetViewModels;
        }

        public async Task<IEnumerable<string>> GetTweetsWithUrlsFromAPI(string accountName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.twitter.com/2/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["TwitterConfig:BearerToken"]);

                var response = await client.GetAsync($"users/{accountName}/tweets");
                var responseBody = await response.Content.ReadAsStringAsync();

                return null ;
            }



            ////var client = new TwitterClient(_configuration["TwitterConfig:ApiKey"],
            ////                    _configuration["TwitterConfig:ApiSecret"],
            ////                    _configuration["TwitterConfig:BearerToken"]);
            //var client = new TwitterClient(_configuration["TwitterConfig:ApiKey"],
            //                   _configuration["TwitterConfig:ApiSecret"],
            //                   _configuration["TwitterConfig:AccessToken"],
            //                   _configuration["TwitterConfig:AccessTokenSecret"]); 



            //var user = await client.Users.GetUserAsync(accountName);
            //var tweets = await user.GetUserTimelineAsync();

            //// Filter tweets with URLs
            //IEnumerable<string> tweetsWithUrls = tweets.Where(t => t.Urls.Any()).Select(t => t.FullText).ToList();

            //return tweetsWithUrls;
        }

        public async Task AddTweetsFromApiToDb(string accountName)
        {
            IEnumerable<string> tweetsWithUrls = await GetTweetsWithUrlsFromAPI(accountName);

            List<Tweet> tweetEntities = tweetsWithUrls.Select(t => new Tweet
            {
                TweetContent = t,
            }).ToList();

            await _unitOfWork.Tweets.AddRangeAsync(tweetEntities);
            await _unitOfWork.CommitAsync();
        }


    }

}
