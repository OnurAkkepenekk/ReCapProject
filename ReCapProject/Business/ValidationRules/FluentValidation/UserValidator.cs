using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
        }

        /*private bool ValidatePassword(string arg)
        {
            bool upper = false;
            bool lower = false;
            bool num = false;

            foreach (char item in arg)
            {
                if (char.IsUpper(item))
                    upper = true;
                else if (char.IsLower(item))
                    lower = true;
                else if (char.IsDigit(item))
                    num = true;
            }
            bool validate = upper && lower && num;
            return validate;
        }*/
    }
}
