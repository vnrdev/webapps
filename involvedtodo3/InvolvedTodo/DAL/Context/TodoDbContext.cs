using System.Data.Entity;
using InvolvedTodo.DAL.Models;
using InvolvedTodo.Migrations;

namespace InvolvedTodo.DAL.Context
{
    public class TodoDbContext : DbContext
    {                
        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<TodoList> TodoList { get; set; }

        public TodoDbContext() : base("TodoDB")
        {            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodoDbContext, Configuration>());
        }
      }

}