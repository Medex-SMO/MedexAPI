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
        public string Code { get; set; }
        public string Name { get; set; }
        public string Indication { get; set; }
    }
}
