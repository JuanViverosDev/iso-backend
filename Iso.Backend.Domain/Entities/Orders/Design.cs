

using Iso.Backend.Domain.Entities.Base;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class Design : DomainObject
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<CommentItem> Comments { get; set; }
        public string MainImage { get; set; } = string.Empty;
    }
}
