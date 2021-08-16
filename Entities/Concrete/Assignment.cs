using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Assignment : IEntity
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int UserId { get; set; }
        public string CraName { get; set; }
        public bool Status { get; set; }
    }
}
