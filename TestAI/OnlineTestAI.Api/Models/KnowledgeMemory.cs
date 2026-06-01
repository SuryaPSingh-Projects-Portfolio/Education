using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineTestAI.Api.Models;

public class KnowledgeMemory
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public string Content { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Source { get; set; }
    
    [MaxLength(100)]
    public string? Type { get; set; } // "document", "search", "manual"
    
    public string? Topics { get; set; } // JSON array of topics
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
