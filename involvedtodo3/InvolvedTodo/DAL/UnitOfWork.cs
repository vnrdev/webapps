using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using InvolvedTodo.DAL.Context;
using InvolvedTodo.DAL.Repos;
using InvolvedTodo.DAL.Repos.Interfaces;

namespace InvolvedTodo.DAL
{    
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TodoDbContext _context;

        public UnitOfWork()
        {
            _context = new TodoDbContext();            
            TodoItems = new TodoItemRepository(_context);
            TodoLists = new TodoListRepository(_context);
        }
        
        public TodoItemRepository TodoItems { get; set; }
        public TodoListRepository TodoLists { get; set; }
        
        public void Save()
        {
            _context.SaveChanges();
        }        

        public void Dispose()
        {
            _context.Dispose();            
        }
    }
}