using System.ComponentModel.DataAnnotations;

namespace OnlineTestAI.Api.Models;

public class TestQuestion
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid TestId { get; set; }
    
    public Test? Test { get; set; }
    
    [Required]
    public Guid QuestionId { get; set; }
    
    public Question? Question { get; set; }
    
    public int Order { get; set; }
}
