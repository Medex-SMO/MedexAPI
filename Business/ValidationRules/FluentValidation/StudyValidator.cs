using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class StudyValidator : AbstractValidator<Study>
    {
        public StudyValidator()
        {
            RuleFor(s => s.SponsorId).NotEmpty();
        }
    }
}

