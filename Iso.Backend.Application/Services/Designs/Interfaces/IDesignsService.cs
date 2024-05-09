// using Iso.Backend.Application.DTO.;

using Iso.Backend.Application.DTO.Items;

namespace Iso.Backend.Application.Services.Orders.Interfaces
{
    public interface IDesignsService
    {
        public Task<IEnumerable<DesignResponseDTO>> GetDesigns();

        public Task<DesignResponseDTO> GetDesign(Guid id);
        public Task<DesignResponseDTO> CreateDesign(DesignCreateDTO design);
        public Task<DesignResponseDTO> UpdateDesign(Guid id, DesignCreateDTO design);
        public Task<DesignResponseDTO> DeleteDesign(Guid id);
    }
}