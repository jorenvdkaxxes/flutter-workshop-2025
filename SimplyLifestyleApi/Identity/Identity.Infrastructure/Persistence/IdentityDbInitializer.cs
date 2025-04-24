using Common.Domain;
using Common.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Identity.Infrastructure;

internal class IdentityDbInitializer : DbInitializer
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;

    public IdentityDbInitializer(
        IdentityDbContext db,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config,
        ILogger<IdentityDbInitializer> logger)
        : base(db, logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
    }

    public override int Index => 0;

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        await SeedAdministrator();
        await SeedTestUser();
    }

    private async Task SeedAdministrator()
    {
        var existingRole = await _roleManager.FindByNameAsync(CommonModelConstants.Common.AdministratorRoleName);

        if (existingRole != null) return;

        var adminRole = new IdentityRole(CommonModelConstants.Common.AdministratorRoleName);

        await _roleManager.CreateAsync(adminRole);

        // Get admin account from secrets
        var email = _config["AdminUser:Email"];
        if (string.IsNullOrEmpty(email))
            email = "admin@simply-lifestyle.be";

        var password = _config["AdminUser:Password"];
        if (string.IsNullOrEmpty(password))
            password = "Admin123!";

        var adminUser = new User(email);

        await _userManager.CreateAsync(adminUser, password);
        await _userManager.AddToRoleAsync(adminUser, CommonModelConstants.Common.AdministratorRoleName);
    }

    private async Task SeedTestUser()
    {
        var existingRole = await _roleManager.FindByNameAsync(CommonModelConstants.Common.TestUserRoleName);

        if (existingRole != null) return;

        var testUserRole = new IdentityRole(CommonModelConstants.Common.TestUserRoleName);

        await _roleManager.CreateAsync(testUserRole);

        // Get admin account from secrets
        var email = _config["TestUser:Email"];
        if (string.IsNullOrEmpty(email))
            email = "test-user@simply-lifestyle.be";

        var password = _config["TestUser:Password"];
        if (string.IsNullOrEmpty(password))
            password = "Test123!";

        var adminUser = new User(email);

        await _userManager.CreateAsync(adminUser, password);
        await _userManager.AddToRoleAsync(adminUser, CommonModelConstants.Common.TestUserRoleName);
    }
}