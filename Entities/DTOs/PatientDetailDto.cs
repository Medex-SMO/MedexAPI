using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PatientDetailDto : IDto
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }
        public string ProtocolCode { get; set; }
        public string No { get; set; }
    }
}
