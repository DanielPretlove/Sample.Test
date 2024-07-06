using Sample.Test.Application.Common.Interfaces;
using Sample.Test.Domain.Entities;
using Sample.Test.Domain.Events;

namespace Sample.Test.Application.User.Commands.CreateUser
{
    public record CreateUserCommand : IRequest<int>
    {
        public int UserID { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public DateTime DateAdded  { get; init; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context) 
        {
            _context = context;
        }


        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new Sample.Test.Domain.Entities.User
            {
                UserID = request.UserID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DateAdded = request.DateAdded

            };

            entity.AddDomainEvent(new UserCreatedEvent(entity));

            _context.AllUsers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }
    }
}