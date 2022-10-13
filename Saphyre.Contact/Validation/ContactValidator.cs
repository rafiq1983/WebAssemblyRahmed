// Copyright NantHealth, LLC. 2020

using System;
using System.Linq.Expressions;
using FluentValidation;
using Saphyre.Contact.Model;

namespace Validation
{
    /// <summary>
    /// Validation class for contacts
    /// </summary>
    public class ContactValidator : AbstractValidator<Contact>
    {

        public ContactValidator()
        {


            RuleFor(p => p.id)
             .NotEmpty().WithMessage("Id is required.");

            RuleFor(p => p.firstName)
                .NotEmpty().WithMessage("First Name is required.");
            RuleFor(p => p.lastName)
                .NotEmpty().WithMessage("Last Name is required.");
            RuleFor(p => p.age)
                .NotEmpty().WithMessage("Age is required.");

            RuleFor(p => p.phone)
               .NotEmpty().WithMessage("Phone is required.");
            RuleFor(p => p.address)
                .NotEmpty().WithMessage("Address is required.");
         
        }
    }
}
