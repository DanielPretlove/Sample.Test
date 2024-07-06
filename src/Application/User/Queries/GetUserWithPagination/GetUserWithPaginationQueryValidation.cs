using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Test.Application.User.Queries.GetUserWithPagination
{
    public class GetUserWithPaginationQueryValidation : AbstractValidator<GetUserWithPaginationQuery>
    {
        public GetUserWithPaginationQueryValidation()
        {
             RuleFor(x => x.UserID)
            .NotEmpty().WithMessage("UserID is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}