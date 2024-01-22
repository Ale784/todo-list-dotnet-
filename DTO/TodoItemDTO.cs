using System.ComponentModel.DataAnnotations.Schema;
using TodoList.models;

namespace TodoList.DTO;

public record TodoItemDTO{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastModified { get; set; }

}