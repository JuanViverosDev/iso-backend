

using Iso.Backend.Domain.Entities.Base;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class Design : DomainObject
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
