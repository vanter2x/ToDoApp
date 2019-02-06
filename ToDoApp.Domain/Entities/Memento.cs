using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Domain.Entities
{
    public class Memento : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        
    }
}   