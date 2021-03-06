﻿using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<bool>
    {
        public int CustomerAddressID { get; set; }
        public int CustomerID { get; set; }
        public DeleteAddressCommand(int id, int customerId)
        {
            CustomerAddressID = id;
            CustomerID = customerId;
        }
    }

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _context.CustomerAddresses
                    .SingleOrDefaultAsync(a => a.ID == request.CustomerAddressID && a.CustomerID == request.CustomerID);

                if (record != null)
                {
                    _context.CustomerAddresses.Remove(record);

                    //remove all duplicated addresses
                    var data = from ca in _context.CustomerAddresses.AsEnumerable()
                               where ca.Equals(record)
                               select ca;

                    if(data != null && data.Count() != 0)
                        _context.CustomerAddresses.RemoveRange(data);

                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return true;
        }
    }

}
