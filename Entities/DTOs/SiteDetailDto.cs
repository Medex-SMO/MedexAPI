using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class SiteDetailDto : IDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StudyCode { get; set; }
        public string StudyName { get; set; }
        public string StudySponsorName { get; set; }
        public string Number { get; set; }
        public string HospitalName { get; set; }
        public string Department { get; set; }
        public string Investigator { get; set; }
        public string CraName { get; set; }
        public string CraMail { get; set; }
        public string CraMobile { get; set; }
    }
}
