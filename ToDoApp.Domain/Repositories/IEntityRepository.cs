using System.Collections.Generic;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Repositories
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetSingle(int id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
    }
}