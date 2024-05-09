using Iso.Backend.Application.Base;
using Iso.Backend.Application.Common.Interfaces;
using Iso.Backend.Domain.Entities.Orders;
using Iso.Backend.Infrastructure.Context;

namespace Dissau.DigisignCol.Infrastructure.Persistence
{
    public class DesignRepository : RepositoryBase<Design, IsoBackendDbContext>, IDesignRepository
    {
        public DesignRepository(IsoBackendDbContext db) : base(db)
        {
        }
    }
}