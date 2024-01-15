using System.ComponentModel.DataAnnotations.Schema;
using TodoList.models;

namespace TodoList.DTO;

public class TodoItemDTO{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    
}