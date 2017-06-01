using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvolvedTodo.DAL.Repos.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        TodoItemRepository TodoItems { get; }
        TodoListRepository TodoLists { get; }
        void Save();
    }
}
