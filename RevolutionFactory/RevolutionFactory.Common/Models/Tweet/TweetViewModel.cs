using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionFactory.Common.Models.Tweet
{
    public class TweetViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string TweetId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }

}
