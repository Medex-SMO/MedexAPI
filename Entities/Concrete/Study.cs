using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Study : IEntity
    {
        public int Id { get; set; }
        public int SponsorId { get; set; }
        public string ProtocolCode { get; set; }
        public string StudyName { get; set; }
        public string Indication { get; set; }
    }
}
