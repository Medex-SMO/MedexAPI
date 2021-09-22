using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class SiteValidator : AbstractValidator<Site>
    {
        public SiteValidator()
        {
            RuleFor(s => s.StudyId).NotEmpty();
            RuleFor(s => s.CraMail).EmailAddress();
        }
    }
}

