using Sample.Test.Domain.Entities;

namespace Sample.Test.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Domain.Entities.User> AllUsers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
