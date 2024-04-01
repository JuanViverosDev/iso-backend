

using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using Iso.Backend.Domain.Entities.Base;
using Iso.Backend.Domain.Entities.JsonModels;

namespace Iso.Backend.Domain.Entities.Auth
{
    public class Role : DomainObject
    {
        public string? Name { get; set; } = string.Empty;
        [Column(TypeName = "jsonb")]
        public Permissions Permissions { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
