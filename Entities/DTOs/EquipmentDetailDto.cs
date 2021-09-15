using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EquipmentDetailDto : IDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string Amount { get; set; }
    }
}
