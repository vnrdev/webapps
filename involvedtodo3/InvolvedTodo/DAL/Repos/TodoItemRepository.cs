using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvolvedTodo.DAL.Context;
using InvolvedTodo.DAL.Models;
using InvolvedTodo.DAL.Repos.Interfaces;

namespace InvolvedTodo.DAL.Repos
{
    public class TodoItemRepository : Repository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(TodoDbContext context) : base(context)
        {            
        }
        
        public IEnumerable<TodoItem> GetItemsByListId(int todoListId)
        {
            var itemListItems = Context.TodoItem.Where(i => i.TodoList.Id == todoListId);
            return itemListItems;
        }


    }
}