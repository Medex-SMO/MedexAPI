using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto
    {
        public int SponsorId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyPhone { get; set; }
        public string PersonalPhone { get; set; }
        public string Adress { get; set; }
        public string FullAdress { get; set; }
        //public DateTime LastLogin { get; set; }
        //public string ResetPassword { get; set; }
    }
}
