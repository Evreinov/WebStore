using System;
using System.Collections.Generic;

namespace WebStore.Domain.DTO
{
    /// <summary>
    /// Информация о заказе.
    /// </summary>
    public class OrderDTO
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Номер телефона для связи.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес доставки.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Дата заказа.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Список товара в заказе.
        /// </summary>
        public IEnumerable<OrderItemDTO> Items { get; set; }
    }
}
