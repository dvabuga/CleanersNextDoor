﻿using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerModel>
    {
        public int CustomerID { get; set; }
        public GetCustomerQuery(int customerId)
        {
            CustomerID = customerId;
        }
    }

    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerModel>
    {
        private readonly ICleanersNextDoorContext _context;
        private IMapper _mapper;

        public GetCustomerQueryHandler(
            ICleanersNextDoorContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CustomerModel> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.FindAsync(request.CustomerID);
            if (entity == null) return new CustomerModel();

            var customer = _mapper.Map<CustomerModel>(entity);
            customer.HasAddresses = _context.CustomerAddresses.Any(a => a.CustomerID == request.CustomerID);
            customer.HasPaymentMethods = _context.PaymentMethods.Any(p => p.CustomerID == request.CustomerID);
            return customer;
        }
    }
}
