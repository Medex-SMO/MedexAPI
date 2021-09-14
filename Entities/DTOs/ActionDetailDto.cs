using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ActionDetailDto : IDto
    {
        public int Id { get; set; }
        public string CraName { get; set; }
        public string PatientNo { get; set; }
        public string VisitType { get; set; }
        public DateTime ActionDate { get; set; }
        public DateTime PlanDate { get; set; }
        public int Duration { get; set; }
        public string Details { get; set; }
    }
}
