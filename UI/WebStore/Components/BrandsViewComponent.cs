using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;

namespace WebStore.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;
        public BrandsViewComponent(IProductData ProductData) => _ProductData = ProductData;
        public IViewComponentResult Invoke() => View(GetBrands());
        private IEnumerable<BrandsViewModel> GetBrands() =>
            _ProductData.GetBrands()
            .OrderBy(brand => brand.Order)
            .Select(brand => new BrandsViewModel
            {
                Id = brand.Id,
                Name = brand.Name,
                ProductsCount = _ProductData.GetProducts(new Domain.ProductFilter { BrandId = brand.Id }).Count()
            });
    }
}
