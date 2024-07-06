using Sample.Test.Application.User.Commands.CreateUser;
public class CreateTodoItemCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(250)
            .NotEmpty();
        RuleFor(v => v.LastName)
            .MaximumLength(250)
            .NotEmpty();
        RuleFor(v => v.Email)
            .MaximumLength(250)
            .NotEmpty();
    }
}
