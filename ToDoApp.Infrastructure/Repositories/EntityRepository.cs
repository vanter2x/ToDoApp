using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Repositories;

namespace ToDoApp.Infrastructure.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntity
    {
        private AppDbContext _context;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
        }

        public RepositoryResult Add(T entity)
        {
            _context.Set<T>().Add(entity);
            var result = Save();

            return result;
        }

        public RepositoryResult Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            var result = Save();

            return result;
        }

        public RepositoryResult Edit(T entity)
        {
            _context.Set<T>().Update(entity);
            var result = Save();

            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetSingle(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        private RepositoryResult Save()
        {
            RepositoryResult result = new RepositoryResult("Database updated successfully");
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                result.RepositoryStatus = RepositoryResultStatus.Error;
                result.Message = e.Message;
            }

            return result;
        }
    }
}