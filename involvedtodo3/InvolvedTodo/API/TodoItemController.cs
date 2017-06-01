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
    [RoutePrefix("api/todoitem")]
    public class TodoItemController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public TodoItemController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [Route("")]
        public List<TodoItem> GetAllItems()
        {
            return _uow.TodoItems.GetAll() as List<TodoItem>;
        }

        [HttpGet]
        [Route("itemsbylist/{todoListId}")]
        public HttpResponseMessage GetItemsByListId(int todoListId)
        {
            var itemList = _uow.TodoLists.Get(todoListId);
            if (itemList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Could not find requested TodoList with id {todoListId}");
            }
            var itemListItems = _uow.TodoItems.GetItemsByListId(todoListId);            
            return Request.CreateResponse(HttpStatusCode.OK, itemListItems);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetItem(int id)
        {
            var item = _uow.TodoItems.Get(id);
            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Item with id {id} was not found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage EditItem(int id, TodoItemModel updatedItem)
        {
            if (updatedItem == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Please provide a valid item.");
            }
            var item = _uow.TodoItems.Get(id);
            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Item with id {id} was not found.");
            }
            item.Title = updatedItem.Title;
            item.Content = updatedItem.Content;
            item.Done = updatedItem.Done;
            try
            {
                _uow.Save();
                return Request.CreateResponse(HttpStatusCode.OK, "Item successfully updated.");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not update item: {error.ErrorMessage}");
            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteItem(int id)
        {
            var item = _uow.TodoItems.Get(id);
            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Item with id {id} was not found.");
            }
            _uow.TodoItems.Remove(item);                                    
            _uow.Save();
            
            return Request.CreateResponse(HttpStatusCode.OK, "Item successfully deleted.");
        }

        [HttpPut]
        [Route("{id}/toggledone")]
        public HttpResponseMessage ToggleDone(int id)
        {
            var todoItem = _uow.TodoItems.Get(id);
            if (todoItem == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not find requested TodoItem with id {id}");
            }
            todoItem.Done = !todoItem.Done;
            _uow.Save();

            var done = todoItem.Done;
            var response = done ? "completed" : "not completed";

            return Request.CreateResponse(HttpStatusCode.OK, $"Item successfully updated to {response}");
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage AddItemToLastList(TodoItemModel newTodoItem)
        {
            if (newTodoItem == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Please provide a valid item.");
            }
            var itemList = _uow.TodoLists.GetLastList();
            if (itemList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Could not add item to List because the requested List could not be found.");
            }
            var todoItem = new TodoItem
            {
                Done = newTodoItem.Done,
                Title = newTodoItem.Title,
                Content = newTodoItem.Content
            };

            itemList.Todos.Add(todoItem);
            try
            {
                _uow.Save();
                return Request.CreateResponse(HttpStatusCode.Created, "Item successfully created.");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not add item to list: {error.ErrorMessage}");
            }            
        }

        [HttpPost]
        [Route("{id}/movetolist/{listid}")]
        public HttpResponseMessage MoveToList(int id, int listId)
        {
            var item = _uow.TodoItems.Get(id);
            if (item == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Item with id {id} was not found.");
            }
            var itemList = _uow.TodoLists.Get(listId);
            if (itemList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Could not move item: could not find requested TodoList with id {listId}");
            }
            item.TodoList = itemList;
            _uow.Save();
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        protected override void Dispose(bool disposing)
        {
            _uow.Dispose();
            base.Dispose(disposing);
        }

    }
}