using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walmar.DLL
{
    public class GoodsReview
    {
        public Guid Id { get; set; }
        public string ReviewIdWalmar { get; set; }
        public string ReviewText { get; set; }

        public Guid GoodId { get; set; }
        public virtual Goods Good { get; set; }
    }
}
