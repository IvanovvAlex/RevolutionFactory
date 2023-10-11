using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionFactory.Data.Entities
{
    public class Tweet
    {
        [Key]
        [MaxLength(50)]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string TweetId { get; set; }

        [Required]
        public string TweetContent { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

    }
}
