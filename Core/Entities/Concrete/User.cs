using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int SponsorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyPhone { get; set; }
        public string PersonalPhone { get; set; }
        public string City { get; set; }
        public string FullAdress { get; set; }
        //public DateTime LastLogin { get; set; }
        //public string ResetPassword { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
