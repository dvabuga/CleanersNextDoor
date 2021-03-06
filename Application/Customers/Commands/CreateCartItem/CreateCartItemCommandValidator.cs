﻿using Application.Common.Interfaces;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands.CreateCartItem
{
    public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateCartItemCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ItemID)
                .NotEmpty()
                .MustAsync(BeValidItem)
                    .WithMessage("The item does not exist or is not active.");

            RuleFor(l => l.ItemID).MustAsync(BeLessThanOrEqualToMaxAllowed)
                    .WithMessage("Cannot exceed the maximum allowed for this item.");
        }
        public async Task<bool> BeValidItem(int itemId,
            CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(itemId);
            return item != null && item.Active;
        }
        public async Task<bool> BeLessThanOrEqualToMaxAllowed(CreateCartItemCommand args, int itemId, 
            CancellationToken cancellationToken)
        {
            var data = await Task.FromResult(from li in _context.LineItems.AsEnumerable()
                                             join i in _context.Items.AsEnumerable() on li.ItemID equals i.ID
                                             where li.OrderID == args.OrderID && li.ItemID == args.ItemID
                                             select new { li, i });

            if (data == null || data.FirstOrDefault() == null) return true;
            var item = data.First().i;
            var newQty = data.Count() + args.NewQty;
            return newQty <= item.MaxAllowed;

        }
    }
}
