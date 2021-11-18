using System;
using System.Linq.Expressions;

namespace ProjectMVC.Repository.Interface
{
    public interface IRepositoryBase<Entidade> where Entidade : class
    {
        Entidade GetFirst(Expression<Func<Entidade, bool>> predicate);
        Entidade InsertDb(Entidade entity);
        Entidade UpdateDb(Entidade entity);
        void Commit();
        public void Dispose();
    }
}
