using System.Collections.Generic;

namespace ToDoApp.Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Memento> Mementos { get; set; }
    }
}