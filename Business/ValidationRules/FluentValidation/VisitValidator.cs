using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class VisitValidator : AbstractValidator<Visit>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string VisitNo { get; set; }
        public DateTime VisitDate { get; set; }
        public int TimeSpent { get; set; }
        public string Description { get; set; }
        public VisitValidator()
        {
            RuleFor(v => v.PatientId).NotNull();
            RuleFor(v => v.VisitNo).NotEmpty();
        }
    }
}

