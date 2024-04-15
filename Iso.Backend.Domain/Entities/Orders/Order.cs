

using System.ComponentModel.DataAnnotations.Schema;
using Iso.Backend.Domain.Entities.Base;
using Iso.Backend.Domain.Entities.JsonModels;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class Order : DomainObject
    {
        public Guid UserId { get; set; }
        public string State { get; set; } = string.Empty;
        public ICollection<OrderDetail> OrderDetails { get; set; }
        [Column(TypeName = "jsonb")]
        public OrderDetails? Details { get; set; }
    }
}
