using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Infrastructure
{
    public class DbInitializer
    {
        public static string Seed(AppDbContext context)
        {
            string info = "";
            if (!context.Categories.Any())
            {
                context.AddRange(
                    new Category() { Name = "Shopping" },
                    new Category() { Name = "House" },
                    new Category() { Name = "Work" }
                    );
                context.SaveChanges();
            }

            if (!context.Mementos.Any())
            {
                var x = Queryable.FirstOrDefault(context.Categories).Id;
                context.AddRange(
                    new Memento() { CategoryId = x, Done = false, Text = "Pants" },
                    new Memento() { CategoryId = x, Done = false, Text = "T-Shirt" },
                    new Memento() { CategoryId = x+1, Done = false, Text = "Cleaning" },
                    new Memento() { CategoryId = x+2, Done = false, Text = "Talking with boss" },
                    new Memento() { CategoryId = x+2, Done = false, Text = "Make research" },
                    new Memento() { CategoryId = x+2, Done = false, Text = "Find new job" }
                    );
                info = "Database Seeding Complete!";
            }
            context.SaveChanges();

            return info;
        }
    }
}