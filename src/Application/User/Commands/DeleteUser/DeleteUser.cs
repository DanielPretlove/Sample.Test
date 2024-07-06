using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Test.Application.Common.Interfaces;
using Sample.Test.Domain.Events;

namespace Sample.Test.Application.User.Commands.DeleteUser;
public record DeleteUserCommand(int Id) : IRequest;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.AllUsers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.AllUsers.Remove(entity);

        entity.AddDomainEvent(new UserDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}