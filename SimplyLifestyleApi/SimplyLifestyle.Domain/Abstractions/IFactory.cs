using SimplyLifestyle.Utils;

namespace SimplyLifestyle.Domain;

public interface IFactory<TEntity>
    where TEntity : IAggregateRoot
{
    OperationResult<TEntity> Build();

    Task<OperationResult<TEntity>> BuildAsync();
}
