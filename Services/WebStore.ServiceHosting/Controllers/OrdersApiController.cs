using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Domain.DTO;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    /// <summary>
    /// Управление заказами
    /// </summary>
    [Route(WebAPI.Orders)]
    [ApiController]
    public class OrdersApiController : ControllerBase, IOrderService
    {
        private readonly IOrderService _OrderService;

        public OrdersApiController(IOrderService OrderService) => _OrderService = OrderService;
        
        /// <summary>
        /// Создает новый заказ.
        /// </summary>
        /// <param name="UserName">Имя пользователя</param>
        /// <param name="OrderModel">Заказ</param>
        /// <returns></returns>
        [HttpPost("{UserName}")]
        public Task<OrderDTO> CreateOrder(string UserName, CreateOrderModel OrderModel) => _OrderService.CreateOrder(UserName, OrderModel);
        
        /// <summary>
        /// Получает заказ, по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public Task<OrderDTO> GetOrderById(int id) => _OrderService.GetOrderById(id);
        
        /// <summary>
        /// Получает список заказов, указанного пользователя.
        /// </summary>
        /// <param name="UserName">Имя пользователя</param>
        /// <returns>Список заказов.</returns>
        [HttpGet("user/{UserName}")]
        public Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName) => _OrderService.GetUserOrders(UserName);
    }
}
