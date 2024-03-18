using System.ComponentModel.DataAnnotations;
using Iso.Domain.Backend.Domain.Entities.Base;

namespace Iso.Backend.Domain.Entities.Base;
public abstract class DomainObject : DomainBaseObject
{
    [Key]
    public Guid Id { get; set; }

    public override bool Equals(object obj)
    {
        var item = obj as DomainObject;
        if (item == null)
        {
            return false;
        }
        return this.Id.Equals(item.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}