

using Iso.Backend.Domain.Entities.Base;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class OrderDetail : DomainObject
    {
        public Guid ItemId { get; set; }
        public Guid DesignId { get; set; }
        public Guid OrderId { get; set; }
    }
}
