using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineTestAI.Api.Models;

public class TestResult
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid TestId { get; set; }
    
    [JsonIgnore]
    public Test? Test { get; set; }
    
    public int Score { get; set; } // percentage
    
    public string Answers { get; set; } = string.Empty; // JSON object with questionId: answer
    
    public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
    
    [MaxLength(200)]
    public string? UserName { get; set; }
}
