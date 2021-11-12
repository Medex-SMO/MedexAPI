using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AssignmentDetailDto :IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SponsorName { get; set; }
        public string ProtocolCode { get; set; }
        public string SiteName { get; set; }
        public string SiteNumber { get; set; }
        public string Email{ get; set; }
        public bool Status { get; set; }
    }
}
