using System.Collections.Generic;
using InvolvedTodo.DAL.Context;

namespace InvolvedTodo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TodoDbContext context)
        {
//            context.TodoList.AddOrUpdate(
//                list => list.Title,
//                    new TodoList
//                    {
//                        Title = "List"                        
//                    }
//            );
//
//            context.SaveChanges();
//
//            var list1 = context.TodoList.First(t => t.Title == "List");
//
//            var items = new List<TodoItem>
//            {
//                new TodoItem { Title = "TodoItem", Content = "Clean house", Done = false, TodoListId = list1.Id},
//                new TodoItem { Title = "TodoItem", Content = "Clean room", Done = false, TodoListId = list1.Id},
//                new TodoItem { Title = "TodoItem", Content = "Clean yard", Done = false, TodoListId = list1.Id}
//            };
//
//            context.TodoItem.AddOrUpdate(
//                i => i.Content,
//                    items.ToArray()
//                );
//            context.SaveChanges();
        }
    }
}
