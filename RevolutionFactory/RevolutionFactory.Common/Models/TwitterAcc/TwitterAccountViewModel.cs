using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionFactory.Common.Models.TwitterAcc
{
    public class TwitterAccountViewModel
    {
        [Required]
        public string AccountName { get; set; }
    }

}
