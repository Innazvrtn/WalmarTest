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
    public class GoodRepository: IRepository<Goods>
    { 
        private MalmarContext db;

        public GoodRepository(MalmarContext context)
        {
            this.db = context;
        }

        public IEnumerable<Goods> GetAll()
        {
            return db.Goodss;
        }

        public Goods Get(int id)
        {
            return db.Goodss.Find(id);
        }

        public void Create(IEnumerable<Goods> good)
        {
            db.Goodss.AddRange(good);

        }

        public void Update(Goods good)
        {
            db.Entry(good).State = EntityState.Modified;
        }

        public IEnumerable<Goods> Find(Func<Goods, Boolean> predicate)
        {
            return db.Goodss.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Goods good = db.Goodss.Find(id);
            if (good != null)
                db.Goodss.Remove(good);
        }
    }
}
