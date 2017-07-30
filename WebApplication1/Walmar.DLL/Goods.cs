using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walmar.DLL
{
   public class Goods
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<GoodsReview> GoodsReviews { get; set; }

        public Goods()
        {
            GoodsReviews = new List<GoodsReview>();
        }
    }
}
