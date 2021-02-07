using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    public class Product : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Номер секции
        /// </summary>
        public int SectionId { get; set; }
        /// <summary>
        /// Номер бренда
        /// </summary>
        public int? BrandId { get; set; }
        /// <summary>
        /// Адрес картинки
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
    }
}
