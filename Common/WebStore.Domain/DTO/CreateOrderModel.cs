using System.Collections.Generic;
using WebStore.Domain.ViewModels;

namespace WebStore.Domain.DTO
{
    /// <summary>
    /// Модель процесса создания заказ.
    /// </summary>
    public class CreateOrderModel
    {
        /// <summary>
        /// Модель заказа.
        /// </summary>
        public OrderViewModel Order { get; set; }

        /// <summary>
        /// Список товара.
        /// </summary>
        public IList<OrderItemDTO> Items { get; set; }
    }
}
