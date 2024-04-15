

using Iso.Backend.Domain.Entities.Base;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class Order : DomainObject
    {
        public Guid UserId { get; set; }
        public string State { get; set; } = string.Empty;
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
