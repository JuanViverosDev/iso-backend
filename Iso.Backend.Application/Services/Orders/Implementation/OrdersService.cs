using AutoMapper;
using Iso.Backend.Application.Common.Interfaces;
using Iso.Backend.Application.DTO.Items;
using Iso.Backend.Application.Services.Orders.Interfaces;
using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.Services.Orders.Implementation
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrdersService(IMapper mapper, IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderResponseDTO> CreateOrder(OrderCreateDTO orderCreateDTO)
        {
            try
            {
                var order = _mapper.Map<Order>(orderCreateDTO);
                order.OrderDetails = _mapper.Map<List<OrderDetail>>(orderCreateDTO.OrderDetails);
                var result = await _orderRepository.AddAsync(order);
                return _mapper.Map<OrderResponseDTO>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<OrderResponseDTO> GetOrder(Guid orderId)
        {
            try
            {
                var result = await _orderRepository.FindOneAsync(x => x.Id == orderId, x => x.OrderDetails);
                if (result == null)
                {
                    throw new Exception("Order not found");
                }

                return _mapper.Map<OrderResponseDTO>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<OrderResponseDTO>> GetOrders()
        {
            try
            {
                var result = await _orderRepository.FindAsync(x => x.IsActive == true, x => x.OrderDetails);
                return _mapper.Map<List<OrderResponseDTO>>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public async Task<OrderResponseDTO> UpdateOrder(Guid orderId, OrderCreateDTO orderCreateDTO)
        {
            try
            {
                var order = await _orderRepository.FindOneAsync(x => x.Id == orderId);
                if (order == null)
                {
                    throw new Exception("Order not found");
                }

                order.State = orderCreateDTO.State;
                order.OrderDetails = _mapper.Map<List<OrderDetail>>(orderCreateDTO.OrderDetails);
                await _orderRepository.UpdateAsync(order);
                return _mapper.Map<OrderResponseDTO>(order);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public async Task<OrderResponseDTO> DeleteOrder(Guid orderId)
        {
            try
            {
                var order = await _orderRepository.FindOneAsync(x => x.Id == orderId);
                if (order == null)
                {
                    throw new Exception("Order not found");
                }

                order.IsActive = false;
                order.IsDeleted = true;
                await _orderRepository.UpdateAsync(order);
                return _mapper.Map<OrderResponseDTO>(order);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public async Task<OrderResponseDTO> CreateOrderDetail(OrderDetailCreateDTO orderDetailCreateDTO)
        {
            try
            {
                var order = await _orderRepository.FindOneAsync(x => x.Id == orderDetailCreateDTO.OrderId, x => x.OrderDetails);
                if (order == null)
                {
                    throw new Exception("Order not found");
                }
                
                var orderDetail = _mapper.Map<OrderDetail>(orderDetailCreateDTO);
                order.OrderDetails.Add(orderDetail);
                await _orderRepository.UpdateAsync(order);
                
                return _mapper.Map<OrderResponseDTO>(order);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}