

using System.ComponentModel.DataAnnotations.Schema;
using Iso.Backend.Domain.Entities.Base;
using Iso.Backend.Domain.Entities.JsonModels;

namespace Iso.Backend.Domain.Entities.Orders
{
    public class Item : DomainObject
    {
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; } = 0;
        public int Availability { get; set; } = 0;
        public Guid CategoryId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<CommentItem> Comments { get; set; }
        [Column(TypeName = "jsonb")]
        public ItemDetails? Details { get; set; }
    }
}
