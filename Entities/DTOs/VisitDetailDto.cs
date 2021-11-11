using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class VisitDetailDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SponsorName { get; set; }
        public string SiteName { get; set; }
        public string SiteNumber { get; set; }
        public string ProtocolCode { get; set; }
        public string SubjectNo { get; set; }
        public string VisitNo { get; set; }
        public DateTime VisitDate { get; set; }
        public int TimeSpent { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
