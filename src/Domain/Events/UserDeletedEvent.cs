namespace Sample.Test.Domain.Events;

public class UserDeletedEvent : BaseEvent
{
    public UserDeletedEvent(User user)
    {
        User = user;
    }

    public User User { get; }
}
