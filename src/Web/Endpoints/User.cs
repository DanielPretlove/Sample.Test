using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Test.Application.Common.Models;
using Sample.Test.Application.User.Commands.CreateUser;
using Sample.Test.Application.User.Commands.DeleteUser;
using Sample.Test.Application.User.Commands.UpdateUser;
using Sample.Test.Application.User.Queries.GetUserWithPagination;

namespace Sample.Test.Web.Endpoints;
public class User : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetUserWithPagination)
            .MapPost(CreateUser)
            .MapPut(UpdateUser, "{id}")
            .MapDelete(DeleteUser, "{id}");
    }


    public Task<PaginatedList<UserBriefDto>> GetUserWithPagination(ISender sender, [AsParameters] GetUserWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateUser(ISender sender, CreateUserCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateUser(ISender sender, int id, UpdateUserCommand command)
    {
        if (id != command.UserID) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteUser(ISender sender, int id)
    {
        await sender.Send(new DeleteUserCommand(id));
        return Results.NoContent();
    }  
}