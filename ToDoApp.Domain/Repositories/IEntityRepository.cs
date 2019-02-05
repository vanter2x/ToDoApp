using System.Collections.Generic;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Repositories
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetSingle(int id);
        RepositoryResult Add(T entity);
        RepositoryResult Edit(T entity);
        RepositoryResult Delete(T entity);
    }
}