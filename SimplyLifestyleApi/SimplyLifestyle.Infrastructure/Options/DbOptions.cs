namespace SimplyLifestyle.Infrastructure;

public class DbOptions
{
    public const string SectionKey = nameof(DbOptions);

    public bool UseSqlServer { get; set; }
}