using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace InvolvedTodo.DAL.Models
{
    [JsonObject(IsReference = true)]
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        public bool Done { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public int TodoListId { get; set; }

        [JsonIgnore]
        public virtual TodoList TodoList { get; set; }       
    }
}