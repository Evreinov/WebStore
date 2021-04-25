using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain;
using WebStore.Domain.DTO;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;
using WebStore.Services.Data;
using WebStore.Services.Mapping;

namespace WebStore.Infrastructure.Services.InMemory
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<BrandDTO> GetBrands() => TestData.Brands.ToDTO();

        public IEnumerable<SectionDTO> GetSections() => TestData.Sections.ToDTO();

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter)
        {
            var query = TestData.Products;

            if (Filter?.SectionId is { } section_id)
                query = query.Where(product => product.SectionId == section_id);

            if (Filter?.BrandId is { } brand_id)
                query = query.Where(product => product.BrandId == brand_id);

            return query.AsEnumerable().ToDTO();
        }

        public ProductDTO GetProductById(int id) => TestData.Products.FirstOrDefault(p => p.Id == id).ToDTO();
    }
}
