﻿using Iso.Backend.Application.Base;
using Iso.Backend.Application.Common.Interfaces;
using Iso.Backend.Domain.Entities.Orders;
using Iso.Backend.Infrastructure.Context;

namespace Dissau.DigisignCol.Infrastructure.Persistence
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail, IsoBackendDbContext>, IOrderDetailRepository
    {
        public OrderDetailRepository(IsoBackendDbContext db) : base(db)
        {
        }
    }
}