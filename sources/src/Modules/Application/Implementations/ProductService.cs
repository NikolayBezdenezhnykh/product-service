using Application.Dtos;
using Application.Interface;
using Infrastructure.ProductProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations
{
    public class ProductService : IProductService
    {
        private const int _minLimit = 5;
        private const int _maxLimit = 10;
        private const int _pageSize = 1;

        private readonly IProductProvider _productProvider;

        public ProductService(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }
        public async Task<(IReadOnlyList<ProductDto>, PaginationParams)> GetProductsAsync()
        {
            return await GetProductsAsync(paginationParams: null);
        }

        public async Task<(IReadOnlyList<ProductDto>, PaginationParams)> GetProductsAsync(PaginationParams paginationParams)
        {
            var pageSize = paginationParams?.PageSize ?? _pageSize;
            var limit = paginationParams?.Limit ?? _minLimit;

            if (pageSize < 1) pageSize = _pageSize;
            if (limit < 1) limit = _minLimit;
            if (limit > 10) limit = _maxLimit;

            var offset = limit * (pageSize - 1);

            var products = await _productProvider.GetProductsAsync(offset, limit);

            return (products.Select(
                p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Price = p.Price,
                    ProductName = p.Name
                }).ToList(),
                new PaginationParams()
                {
                    Limit = limit,
                    PageSize = pageSize,
                });
        }

        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync(long[] ids)
        {
            var products = await _productProvider.GetProductsAsync(ids);

            return products.Select(
                p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Price = p.Price,
                    ProductName = p.Name
                }).ToList();
        }
    }
}
