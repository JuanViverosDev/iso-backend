

using Iso.Backend.Domain.Entities.Base;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class Item : DomainObject
    {
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; } = 0;
        public int Availability { get; set; } = 0;
        public Guid CategoryId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
