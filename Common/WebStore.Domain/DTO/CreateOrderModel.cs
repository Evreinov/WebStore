using System.Collections.Generic;
using WebStore.Domain.ViewModels;

namespace WebStore.Domain.DTO
{
    public class CreateOrderModel
    {
        public OrderViewModel Order { get; set; }

        public IList<OrderItemDTO> Items { get; set; }
    }
}
