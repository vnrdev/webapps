using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvolvedTodo.DAL.Context;
using InvolvedTodo.DAL.Models;
using InvolvedTodo.DAL.Repos.Interfaces;

namespace InvolvedTodo.DAL.Repos
{
    public class TodoListRepository : Repository<TodoList>, ITodoListRepository
    {
        public TodoListRepository(TodoDbContext context) : base(context)
        {
        }

        public TodoList GetLastList()
        {
            return Context.TodoList.ToList().Last();
        }
    }
}