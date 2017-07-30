using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GoodsReviewViewModel
    {
        public Guid Id { get; set; }
        public string ReviewIdWalmar { get; set; }
        public string ReviewText { get; set; }
        public Guid GoodId { get; set; }
    }
}