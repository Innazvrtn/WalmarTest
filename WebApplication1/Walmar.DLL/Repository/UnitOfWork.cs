using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walmar.DLL.EFContext;
using Walmar.DLL.Interface;

namespace Walmar.DLL.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private MalmarContext db;
        private GoodRepository goodRepository;
        private GoodsReviewRepository goodsReviewRepository;
        public UnitOfWork(string connectionString)
        {
            db = new MalmarContext(connectionString);
        }
        public IRepository<Goods> Goods
        {
            get
            {
                if (goodRepository == null)
                    goodRepository = new GoodRepository(db);
                return goodRepository;
            }
        }

        public IRepository<GoodsReview> GoodsReview
        {
            get
            {
                if (goodsReviewRepository == null)
                    goodsReviewRepository = new GoodsReviewRepository(db);
                return goodsReviewRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
