using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walmar.BLL.DTO
{
    public class GoodsReviewDTO
    {
        public Guid Id { get; set; }
        public string ReviewIdWalmar { get; set; }
        public string ReviewText { get; set; }
        public Guid GoodId { get; set; }
    }
}
