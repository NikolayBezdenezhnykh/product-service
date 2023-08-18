using Application.Dtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProductService
    {
        Task<(IReadOnlyList<ProductDto>, PaginationParams)> GetProductsAsync();

        Task<(IReadOnlyList<ProductDto>, PaginationParams)> GetProductsAsync(PaginationParams paginationParams);

        Task<IReadOnlyList<ProductDto>> GetProductsAsync(long[] ids);
    }
}
