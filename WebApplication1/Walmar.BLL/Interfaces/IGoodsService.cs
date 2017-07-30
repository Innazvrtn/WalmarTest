using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walmar.BLL.DTO;

namespace Walmar.BLL.Interfaces
{
    public interface IGoodsService
    {
        void CreateGoods(string url);
        IEnumerable<GoodsReviewDTO> SearchByKeyWords(string word);
        void Dispose();
    }
}
