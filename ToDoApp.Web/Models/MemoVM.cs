using System.Collections.Generic;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Web.Models
{
    public class MemoVM
    {
        public Dictionary<Category, List<Memento>> ToDoList;

        public MemoVM()
        {
            ToDoList = new Dictionary<Category, List<Memento>>();
        }
    }
}