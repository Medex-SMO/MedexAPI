using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Visit : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public string VisitNo { get; set; }
        public DateTime VisitDate { get; set; }
        public int TimeSpent { get; set; }
        public string Description { get; set; }
    }
}
