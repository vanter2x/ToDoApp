using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Domain.Entities
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Memento> Mementos { get; set; }
    }
}