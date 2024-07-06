using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Test.Application.Common.Interfaces;

namespace Sample.Test.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int UserID { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public DateTime DateAdded  { get; init; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;

    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.AllUsers
            .FindAsync(new object[] { request.UserID }, cancellationToken);

        Guard.Against.NotFound(request.UserID, entity);

        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.Email = request.Email;
        entity.DateAdded = request.DateAdded;

        await _context.SaveChangesAsync(cancellationToken);
    }
    }
}