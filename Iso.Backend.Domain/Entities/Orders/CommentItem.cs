

using Iso.Backend.Domain.Entities.Base;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class CommentItem : DomainObject
    {
        public Guid? CommentThreadId { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public Guid DesignId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Order { get; set; } = 0;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
