using System;
using System.Collections.Generic;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => Data.TestData.Brands;

        public IEnumerable<Section> GetSections() => Data.TestData.Sections;
    }
}
