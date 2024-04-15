

using Iso.Backend.Domain.Entities.Base;
using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Domain.Entities.Auth
{
    public class User : DomainObject
    {
        public string? Name { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public virtual ICollection<Role>? RoleUsers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CommentItem> Comments { get; set; }
        public virtual ICollection<Design> Designs { get; set; }
    }
}
