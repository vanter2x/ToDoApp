using Microsoft.EntityFrameworkCore.Internal;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Infrastructure
{
    public class DbInitializer
    {
        public static string Seed(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.AddRange(
                    new Category(){Name = "Shopping"},
                    new Category() { Name = "House"},
                    new Category() { Name = "Work"}
                    );
            }

            if (!context.Mementos.Any())
            {
                context.AddRange(
                    new Memento() { CategoryId = 1, Done = false, Text = "Pants"},                
                    new Memento() { CategoryId = 1, Done = false, Text = "T-Shirt"},                
                    new Memento() { CategoryId = 2, Done = false, Text = "Cleaning"},               
                    new Memento() { CategoryId = 3, Done = false, Text = "Talking with boss"},               
                    new Memento() { CategoryId = 3, Done = false, Text = "Make research"},               
                    new Memento() { CategoryId = 3, Done = false, Text = "Find new job"}
                    );
            }
            context.SaveChanges();

            return "Database Seeding Complete!";
        }
    }
}