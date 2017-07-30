using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walmar.DLL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Goods> Goods { get; }
        IRepository<GoodsReview> GoodsReview { get; }
        void Save();
    }
}
