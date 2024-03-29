﻿using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Users.Queries.GetUserDetails
{
    public class UserDetailsVm
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string PhoneNumber { get; set; }
        public Photo Photo{ get; set; }
    }
}