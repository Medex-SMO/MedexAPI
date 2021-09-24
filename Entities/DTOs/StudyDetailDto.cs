using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class StudyDetailDto : IDto
    {
        public int Id { get; set; }
        public string SponsorName { get; set; }
        public string ProtocolCode { get; set; }
        public string StudyName { get; set; }
        public string Indication { get; set; }
    }
}
