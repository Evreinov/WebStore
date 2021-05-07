namespace WebStore.Domain.DTO
{
    /// <summary>
    /// Товар в заказе.
    /// </summary>
    public class OrderItemDTO
    {
        /// <summary>
        /// Идинтификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Quantity { get; set; }
    }
}
