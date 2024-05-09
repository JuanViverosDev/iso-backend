using AutoMapper;
using Iso.Backend.Application.Common.Interfaces;
using Iso.Backend.Application.DTO.Items;
using Iso.Backend.Application.Services.Orders.Interfaces;
using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.Services.Orders.Implementation
{
    public class DesignsService : IDesignsService
    {
        private readonly IMapper _mapper;
        private readonly IDesignRepository _designRepository;

        public DesignsService(IMapper mapper, IDesignRepository designRepository)
        {
            _mapper = mapper;
            _designRepository = designRepository;
        }

        public async Task<IEnumerable<DesignResponseDTO>> GetDesigns()
        {
            var designs = await _designRepository.FindAsync(d => d.IsActive);
            return _mapper.Map<IEnumerable<DesignResponseDTO>>(designs);
        }
        
        public async Task<DesignResponseDTO> GetDesign(Guid id)
        {
            var design = await _designRepository.FindOneAsync(d => d.Id == id && d.IsActive);
            return _mapper.Map<DesignResponseDTO>(design);
        }
        
        public async Task<DesignResponseDTO> CreateDesign(DesignCreateDTO design)
        {
            var designEntity = _mapper.Map<Design>(design);
            await _designRepository.AddAsync(designEntity);
            return _mapper.Map<DesignResponseDTO>(designEntity);
        }
        
        public async Task<DesignResponseDTO> UpdateDesign(Guid id, DesignCreateDTO design)
        {
            var designEntity = await _designRepository.FindOneAsync(d => d.Id == id && d.IsActive);
            _mapper.Map(design, designEntity);
            await _designRepository.UpdateAsync(designEntity);
            return _mapper.Map<DesignResponseDTO>(designEntity);
        }
        
        public async Task<DesignResponseDTO> DeleteDesign(Guid id)
        {
            var designEntity = await _designRepository.FindOneAsync(d => d.Id == id && d.IsActive);
            designEntity.IsActive = false;
            await _designRepository.UpdateAsync(designEntity);
            return _mapper.Map<DesignResponseDTO>(designEntity);
        }
    }
}