using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public record SectionViewModel
    {
        /// <summary>
        /// Id секции
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Поле упорядовычивания секции
        /// </summary>
        public int Order { get; init; }

        /// <summary>
        /// Родительская секция
        /// </summary>
        public SectionViewModel Parent { get; init; }

        /// <summary>
        /// Список дочерних секций
        /// </summary>
        public List<SectionViewModel> ChildSections { get; } = new();

        /// <summary>
        /// Количество продуктов данной секции
        /// </summary>
        public int ProductsCount { get; set; }

        /// <summary>
        /// Количество товаров вместе с дочерними
        /// </summary>
        public int TotalProductsCount => ProductsCount + ChildSections.Sum(c => c.TotalProductsCount);
    }
}
