using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Business.Repositories
{
    public interface ICoreRepository<T>
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(Guid id);
        public void Delete(T item);
        public void Delete(Expression<Func<T, bool>> expression);

        public T GetById(Guid id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetDefault(Expression<Func<T, bool>> expression);

        public int Save();
        public void RollBack();
        bool Any(Expression<Func<T, bool>> expression);
    }
}
 