using System.ComponentModel.DataAnnotations;

namespace InvolvedTodo.DAL.Models
{
    public class TodoItemModel
    {
        public int Id { get; set; }
        [Required]
        public bool Done { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }                        
    }
}