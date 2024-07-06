using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Test.Application.Common.Interfaces;
using Sample.Test.Application.Common.Mappings;
using Sample.Test.Application.Common.Models;

namespace Sample.Test.Application.User.Queries.GetUserWithPagination;
public record GetUserWithPaginationQuery : IRequest<PaginatedList<UserBriefDto>>
{
    public int UserID { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetUserWithPaginationQueryHandler : IRequestHandler<GetUserWithPaginationQuery, PaginatedList<UserBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UserBriefDto>> Handle(GetUserWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.AllUsers
            .Where(x => x.UserID == request.UserID)
            .OrderBy(x => x.FirstName)
            .ProjectTo<UserBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}