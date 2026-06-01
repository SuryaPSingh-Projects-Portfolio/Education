using Microsoft.EntityFrameworkCore;
using OnlineTestAI.Api.Models;

namespace OnlineTestAI.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<KnowledgeMemory> KnowledgeMemories { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<TestResult> TestResults { get; set; }
    public DbSet<TestQuestion> TestQuestions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure TestQuestion relationship
        modelBuilder.Entity<TestQuestion>()
            .HasOne(tq => tq.Test)
            .WithMany(t => t.TestQuestions)
            .HasForeignKey(tq => tq.TestId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TestQuestion>()
            .HasOne(tq => tq.Question)
            .WithMany(q => q.TestQuestions)
            .HasForeignKey(tq => tq.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure TestResult relationship
        modelBuilder.Entity<TestResult>()
            .HasOne(tr => tr.Test)
            .WithMany(t => t.TestResults)
            .HasForeignKey(tr => tr.TestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
