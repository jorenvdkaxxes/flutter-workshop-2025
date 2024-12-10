using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace SimplyLifestyle.Application;

public interface ITransactionContext
{
    IDbContextTransaction BeginTransaction();

    IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
}
