using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MuchEffective.Core.Entities.Database;

namespace MuchEffective.UseCases.Persistence;

public class DataContext : DbContext {
    private readonly IConfiguration _conf;
    private readonly ILogger<DataContext> _logger;
    public DbSet<DatabaseUser> Users { get; set; }
    public DbSet<DatabaseGroup> Groups { get; set; }
    public DbSet<DatabaseNote> Notes { get; set; }
    public DbSet<DatabaseTask> Tasks { get; set; }
    public DbSet<DatabaseProject> Projects { get; set; }
    public DbSet<DatabasePermission> Permissions { get; set; }
    public DbSet<DatabaseComment> Comments { get; set; }
    public DataContext(IConfiguration configuration, ILogger<DataContext> logger) {
        _conf = configuration;
        _logger = logger;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_conf["ConnectionGuids:Default"]);
    }
}