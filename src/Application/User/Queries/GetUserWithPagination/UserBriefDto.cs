using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Test.Application.User.Queries.GetUserWithPagination
{
    public class UserBriefDto
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public string? Email {get; set;}
        public DateTime DateAdded {get; set;}

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Domain.Entities.User, UserBriefDto>();
            }   
        }
    }
}