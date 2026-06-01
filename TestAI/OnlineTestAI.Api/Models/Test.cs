using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineTestAI.Api.Models;

public class Test
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    
    public string QuestionIds { get; set; } = string.Empty; // JSON array of question IDs
    
    [MaxLength(200)]
    public string? CreatedBy { get; set; }
    
    public int Duration { get; set; } = 30; // minutes
    
    public int PassingScore { get; set; } = 70; // percentage
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [JsonIgnore]
    public List<TestQuestion> TestQuestions { get; set; } = new();
    
    [JsonIgnore]
    public List<TestResult> TestResults { get; set; } = new();
}
