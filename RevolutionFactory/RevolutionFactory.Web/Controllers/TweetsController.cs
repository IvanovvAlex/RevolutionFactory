using Microsoft.AspNetCore.Mvc;
using RevolutionFactory.Domain.Interfaces;

namespace RevolutionFactory.Web.Controllers
{
    public class TweetsController : Controller
    {
        private readonly ITweetService _tweetService;
        public TweetsController(ITweetService tweetService) 
        {
            _tweetService = tweetService;
        }
        public async Task<IActionResult> Index()
        {
            await _tweetService.GetTweetsWithUrlsFromAPI("CNN");

            return View();
        }

    }
}
