/*using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<SurveyResponse> SurveyResponses { get; set; }
    // Add DbSet properties for other entities as needed

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define entity configurations here if needed
    }
}
*/