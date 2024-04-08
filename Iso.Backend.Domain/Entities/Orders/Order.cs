

using Iso.Backend.Domain.Entities.Base;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class Order : DomainObject
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public Guid DesignId { get; set; }
        public string State { get; set; } = string.Empty;
    }
}
