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

        public PageProductsDTO GetProducts(ProductFilter Filter)
        {
            var query = TestData.Products;

            if (Filter?.SectionId is { } section_id)
                query = query.Where(product => product.SectionId == section_id);

            if (Filter?.BrandId is { } brand_id)
                query = query.Where(product => product.BrandId == brand_id);

            var total_count = query.Count();

            if (Filter is { PageSize: > 0 and var page_size, Page: > 0 and var page_number })
                query = query
                    .Skip((page_number - 1) * page_size)
                    .Take(page_size);

            return new PageProductsDTO(query.AsEnumerable().ToDTO(), total_count);
        }

        public ProductDTO GetProductById(int id) => TestData.Products.FirstOrDefault(p => p.Id == id).ToDTO();

        public SectionDTO GetSectionById(int id)
        {
            throw new NotImplementedException();
        }

        public BrandDTO GetBrandByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
