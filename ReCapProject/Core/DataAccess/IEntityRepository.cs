using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Generic Constraint 
    // class : referans tip olabilir anlamındadır.
    // IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    // new() : new'lenebilir olmalıdır.
    public interface IEntityRepository<T>
         where T : class, IEntity, new()
    {
        // Filtre vermeyebilirsin
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        // Filtre vermek zorundasın
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
