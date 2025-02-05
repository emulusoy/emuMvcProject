using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using emuPortfolio.Models.Entity;

namespace emuPortfolio.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        //BEN SIMDI HER YERE AYRI AYRI EKLEME YAPMAK ISTEMIYORUM O YUZDEN TEK BIR YERDEN YAPALIM HER YERDE KULLANALIM GENERIC REP BUNA YARRAAR
        emuPortfolioEntities db=new emuPortfolioEntities();
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public void Tget(int id)
        {
            db.Set<T>().Find(id);
            
        }
        public void TUpdate(T p)
        {
            
            db.SaveChanges();
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);//
        }
    }
}