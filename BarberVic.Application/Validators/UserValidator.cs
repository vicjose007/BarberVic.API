﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberVic.Application.Dtos;
using FluentValidation;
using BarberVic.Application.Validators.Generic;

namespace BarberVic.Application.Validators
{
    public class UserValidator : BaseValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(12).MinimumLength(3);

            RuleFor(x => x.Email).NotEmpty().EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).MaximumLength(12).MinimumLength(3);

            RuleFor<string>(x => x.Password).NotEmpty().MaximumLength(12).MinimumLength(3);

            RuleFor(x => x.Phone).NotEmpty().MaximumLength(12).MinimumLength(3);

            RuleFor(x => x.LastName).NotEmpty().MaximumLength(12).MinimumLength(3);
        }
    }
}

