using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCV.Models.Entity;

namespace MvcCV.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DBCVYapimiEntities m = new DBCVYapimiEntities();

        public List<T> List()
        {
            return m.Set<T>().ToList();
        }

        public void Tadd (T p)
        {
            m.Set<T>().Add(p);
            m.SaveChanges();
        }
        public void  Tdelete (T p)
        {
            m.Set<T>().Remove(p);
            m.SaveChanges();
        }
        public T Tget(int id)
        {
            return m.Set<T>().Find(id);
        }
        public void Tupdate(T p)
        {
            m.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return m.Set<T>().FirstOrDefault(where);//where kontrol tarafında metoda vereceğimiz şart için kullanılır
        }
    }
}