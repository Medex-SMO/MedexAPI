using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Site : IEntity
    {
        public int Id { get; set; }
        public int StudyId { get; set; }
        public int CityId { get; set; }
        public string Number { get; set; }
        public string HospitalName { get; set; }
        public string Department { get; set; }
        public string Investigator { get; set; }
        public string CraName { get; set; }
        public string CraMail { get; set; }
        public string CraMobile { get; set; }
    }
}
