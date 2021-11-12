using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Assignment : IEntity
    {
        public int Id { get; set; }
        public int SponsorId { get; set; }
        public int StudyId { get; set; }
        public int SiteId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
    }
}
