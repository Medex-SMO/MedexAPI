using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ActionValidator : AbstractValidator<Entities.Concrete.Action>
    {
        public ActionValidator()
        {

        }
    }
}

