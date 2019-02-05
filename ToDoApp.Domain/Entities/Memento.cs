namespace ToDoApp.Domain.Entities
{
    public class Memento : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }

        public Category Category { get; set; }
    }
}   