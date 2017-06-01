using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvolvedTodo.DAL;
using InvolvedTodo.DAL.Context;
using InvolvedTodo.DAL.Models;
using InvolvedTodo.DAL.Repos.Interfaces;

namespace InvolvedTodo.API
{        
    [RoutePrefix("api/todolist")]
    public class TodoListController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public TodoListController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [Route("")]        
        public List<TodoList> GetAllTodoLists()
        {
            return _uow.TodoLists.GetAll() as List<TodoList>;            
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetTodoList(int id)
        {
            var itemList = _uow.TodoLists.Get(id);
            if (itemList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Could not find requested TodoList with id {id}");
            }
            return Request.CreateResponse(HttpStatusCode.OK, itemList);
        }       

        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage EditList(int id, TodoList todoList)
        {
            var itemList = _uow.TodoLists.Get(id);
            if (itemList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not update list: Could not find requested TodoList with id {id}");
            }
            itemList.Title = todoList.Title;
            try
            {
               _uow.Save();
                return Request.CreateResponse(HttpStatusCode.OK, "List successfully updated.");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not edit list: {error.ErrorMessage}");
            }                        
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteList(int id)
        {
            var itemList = _uow.TodoLists.Get(id);
            if (itemList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not delete list: Could not find requested TodoList with id {id}");
            }
            _uow.TodoLists.Remove(itemList);
            _uow.Save();
            return Request.CreateResponse(HttpStatusCode.OK, "List successfully deleted.");
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddList(TodoList todoList)
        {
            if (todoList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not add list: please provide a valid TodoList.");
            }
            _uow.TodoLists.Add(todoList);            
            try
            {
                _uow.Save();
                return Request.CreateResponse(HttpStatusCode.Created, todoList);
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();                                
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not create list: {error.ErrorMessage}");
            }            
        }

        [HttpPost]
        [Route("{id}/additem")]
        public HttpResponseMessage AddItem(int id, TodoItem todoItem)
        {
            var itemList = _uow.TodoLists.Get(id);
            if (itemList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not add item: could not find requested TodoList with id {id}");
            }
            if (todoItem == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not add item: please provide a valid TodoItem.");
            }
            itemList.Todos.Add(todoItem);
            try
            {
                _uow.Save();
                return Request.CreateResponse(HttpStatusCode.Created, todoItem);
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not add item to list: {error.ErrorMessage}");
            }

        }        

        protected override void Dispose(bool disposing)
        {
            _uow.Dispose();
            base.Dispose(disposing);                        
        }
    }
}