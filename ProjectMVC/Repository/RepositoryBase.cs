using Microsoft.EntityFrameworkCore;
using ProjectMVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.Repository
{
    public class RepositoryBase<Entidade> : IRepositoryBase<Entidade> where Entidade : class
    {
        private readonly DbContext Context;
        public RepositoryBase(DbContext dbContext)
        {
            Context = dbContext;
        }

        public Entidade InsertDb(Entidade entity)
        {
            Context.Set<Entidade>().Add(entity);
            return entity;
        }

        public Entidade UpdateDb(Entidade entity)
        {
            Context.Set<Entidade>().Update(entity);
            return entity;
        }

        public void Commit()
        {
            Context.SaveChanges();
            Dispose();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Entidade GetFirst(Expression<Func<Entidade, bool>> where)
        {
            return Context.Set<Entidade>().AsQueryable().Where(where).FirstOrDefault();
        }
    }
}
