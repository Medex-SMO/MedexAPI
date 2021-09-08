using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Action : IEntity
    {
        public int Id { get; set; }
        public int AssignId { get; set; }
        public int PatientId { get; set; }
        public string VisitType { get; set; }
        public DateTime ActionDate { get; set; }
        public DateTime PlanDate { get; set; }
        public int Duration { get; set; }
        public string Details { get; set; }
    }
}
