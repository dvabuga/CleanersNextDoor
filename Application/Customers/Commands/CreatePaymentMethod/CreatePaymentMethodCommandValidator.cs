﻿using Application.Common.Interfaces;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands.CreatePaymentMethod
{
    public class CreatePaymentMethodCommandValidator : AbstractValidator<CreatePaymentMethodCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreatePaymentMethodCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(l => l.StripePaymentMethodID).MustAsync(BeValidPaymentMethod)
                    .WithMessage("Must be a valid payment method.");
        }
        public async Task<bool> BeValidPaymentMethod(CreatePaymentMethodCommand args, string stripePaymentMethodID,
            CancellationToken cancellationToken)
        {
            //todo: charge to validate?
            return !string.IsNullOrEmpty(stripePaymentMethodID);
        }
    }
}
