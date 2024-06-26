﻿using System.ComponentModel.DataAnnotations.Schema;
using Iso.Backend.Domain.Entities.Base;
using Iso.Backend.Domain.Entities.JsonModels;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class OrderDetail : DomainObject
    {
        public Guid ItemId { get; set; }
        public Guid? DesignId { get; set; }
        public Guid OrderId { get; set; }
        [Column(TypeName = "jsonb")]
        public OrderDetailsMetadata? Details { get; set; }
    }
}
