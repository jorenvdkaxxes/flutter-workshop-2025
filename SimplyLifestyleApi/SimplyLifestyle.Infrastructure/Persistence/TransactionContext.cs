using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SimplyLifestyle.Application;

namespace SimplyLifestyle.Infrastructure;

public class TransactionContext : ITransactionContext
{
    public TransactionContext(SimplyLifestyleDbContext dbContext) 
    { 
        DbContext = dbContext;
    }

    protected SimplyLifestyleDbContext DbContext { get; } = default!;

    public IDbContextTransaction BeginTransaction()
    {
        return DbContext.Database.BeginTransaction();
    }

    public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
    {
        return DbContext.Database.BeginTransaction(isolationLevel);   
    }
}
