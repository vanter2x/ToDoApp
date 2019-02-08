using System.Collections.Generic;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Web.Models
{
    public class MemosVM
    {
        public List<Category> Categories { get; set; }
        public List<Memento> Mementoes { get; set; }

        public MemosVM()
        {
            Categories = new List<Category>();
            Mementoes = new List<Memento>();
        }
    }
}