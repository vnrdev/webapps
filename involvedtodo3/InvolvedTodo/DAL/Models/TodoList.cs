using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace InvolvedTodo.DAL.Models
{
    [JsonObject(IsReference = true)]
    public class TodoList
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [JsonIgnore]        
        public virtual List<TodoItem> Todos { get; set; }
    }
}