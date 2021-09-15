﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AssignmentDetailDto :IDto
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Email{ get; set; }
        public string CraName { get; set; }
        public bool Status { get; set; }
    }
}
