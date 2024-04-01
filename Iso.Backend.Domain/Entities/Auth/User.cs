﻿

using Iso.Backend.Domain.Entities.Base;

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
    }
}