using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineTestAI.Api.Models;

public class Question
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [MaxLength(2000)]
    public string Content { get; set; } = string.Empty;
    
    [Required]
    public string Options { get; set; } = string.Empty; // JSON array of options
    
    [Required]
    [MaxLength(500)]
    public string CorrectAnswer { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? SourceDocument { get; set; }
    
    [MaxLength(200)]
    public string? Topic { get; set; }
    
    public int Difficulty { get; set; } = 1; // 1-5 scale
    
    public string? KnowledgeTags { get; set; } // JSON array of tags
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [JsonIgnore]
    public List<TestQuestion> TestQuestions { get; set; } = new();
}
