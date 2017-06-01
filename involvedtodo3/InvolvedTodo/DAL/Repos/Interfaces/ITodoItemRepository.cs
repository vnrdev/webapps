using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvolvedTodo.DAL.Models;

namespace InvolvedTodo.DAL.Repos.Interfaces
{
    interface ITodoItemRepository : IRepository<TodoItem>
    {
        IEnumerable<TodoItem> GetItemsByListId(int todoListId);
    }
}
