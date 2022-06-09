using System;
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
            RuleFor(x => x.NameDto).NotEmpty();
        }
    }
}

