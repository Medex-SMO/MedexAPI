using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Patient : IEntity
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public string No { get; set; }
    }
}
