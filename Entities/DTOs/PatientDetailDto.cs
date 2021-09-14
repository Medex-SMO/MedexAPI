using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PatientDetailDto : IDto
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string StudyCode { get; set; }
        public string No { get; set; }
    }
}
