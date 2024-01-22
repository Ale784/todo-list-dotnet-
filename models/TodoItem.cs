using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.models;

public class TodoItem{

    [Key]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Required")]
    [MinLength(3, ErrorMessage = "Minimum 3 characters required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Required")]
    [MinLength(3, ErrorMessage = "Minimum 3 characters required")]
    public string Description { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public DateTime LastModified { get; set; }
    public bool IsCompleted { get; set; }
    public Guid UserId { get; set; } 

    [ForeignKey("UserId")]
    public virtual User User { get; set; }    
    

}