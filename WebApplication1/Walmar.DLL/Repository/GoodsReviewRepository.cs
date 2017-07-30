using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walmar.DLL.EFContext;
using Walmar.DLL.Interface;

namespace Walmar.DLL.Repository
{
    public class GoodsReviewRepository : IRepository<GoodsReview>
    {
        private MalmarContext db;

        public GoodsReviewRepository(MalmarContext context)
        {
            this.db = context;
        }

        public IEnumerable<GoodsReview> GetAll()
        {
            return db.GoodsReviews;
        }

        public GoodsReview Get(int id)
        {
            return db.GoodsReviews.Find(id);
        }

        public void Create(IEnumerable<GoodsReview> review)
        {
            db.GoodsReviews.AddRange(review);
        }

        public void Update(GoodsReview review)
        {
            db.Entry(review).State = EntityState.Modified;
        }

        public IEnumerable<GoodsReview> Find(Func<GoodsReview, Boolean> predicate)
        {
            return db.GoodsReviews.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            GoodsReview review = db.GoodsReviews.Find(id);
            if (review != null)
                db.GoodsReviews.Remove(review);
        }
    }
}
