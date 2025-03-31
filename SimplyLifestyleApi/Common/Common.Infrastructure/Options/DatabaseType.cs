using Common.Domain;

namespace Common.Infrastructure.Options;

public class DatabaseType : Enumeration
{
    public static readonly DatabaseType SqlServer = new(1, "SqlServer");
    public static readonly DatabaseType Sqlite = new(2, "Sqlite");

    private DatabaseType(int value, string name) : base(value, name)
    {
    }

    public static implicit operator int(DatabaseType databaseType) => databaseType.Value;

    public static implicit operator string(DatabaseType databaseType) => databaseType.Name;
}
