namespace TodoList.models;

public class User{

    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string? Username { get; set; }    
    [Required]
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Salt { get; set; }
    public DateTime CreatedOn { get; set; }

}