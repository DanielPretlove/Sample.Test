using Sample.Test.Domain.Entities;

namespace Sample.Test.Domain.Events;

public class UserCompletedEvent : BaseEvent
{
    public UserCompletedEvent(User user)
    {
        User = user;
    }

    public User User { get; }
}
