using System.Reflection;
using Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Common.Infrastructure;

public abstract class DbInitializer : IDbInitializer
{
    private readonly DbContext _db;
    private readonly ILogger<DbInitializer> _logger;
    private readonly IEnumerable<IInitialData> initialDataProviders;

    protected internal DbInitializer(DbContext db, ILogger<DbInitializer> logger)
    {
        _db = db;
        _logger = logger;
        initialDataProviders = new List<IInitialData>();
    }

    protected internal DbInitializer(
        DbContext db,
        ILogger<DbInitializer> logger,
        IEnumerable<IInitialData> initialDataProviders)
        : this(db, logger)
        => this.initialDataProviders = initialDataProviders;

    public virtual void Initialize()
    {
        try
        {
            var pendingMigrations = _db.Database.GetPendingMigrations();

            if (pendingMigrations.Any())
            {
                _logger.LogInformation("Applying pending migrations...");

                _db.Database.Migrate();

                _logger.LogInformation("Migrations applied successfully");
            }
            else
            {
                _logger.LogInformation("No pending migrations to apply");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error appling migrations");
            throw;
        }

        foreach (var initialDataProvider in initialDataProviders)
        {
            if (!DataSetIsEmpty(initialDataProvider.EntityType)) continue;

            var data = initialDataProvider.GetData();
            
            foreach (var entity in data)
            {
                _db.Add(entity);
            }
        }

        _db.SaveChanges();
    }

    private bool DataSetIsEmpty(Type type)
    {
        var setMethod = typeof(DbInitializer)
            .GetMethod(nameof(GetSet), BindingFlags.Instance | BindingFlags.NonPublic)!
            .MakeGenericMethod(type);

        var set = setMethod.Invoke(this, Array.Empty<object>());

        var countMethod = typeof(Queryable)
            .GetMethods()
            .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
            .MakeGenericMethod(type);

        var result = (int)countMethod.Invoke(null, [set])!;

        return result == 0;
    }

    private DbSet<TEntity> GetSet<TEntity>()
        where TEntity : class
        => _db.Set<TEntity>();
}