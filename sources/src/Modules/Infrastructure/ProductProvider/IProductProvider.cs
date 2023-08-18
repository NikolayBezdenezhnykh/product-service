using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ProductProvider
{
    public interface IProductProvider
    {
        Task<IReadOnlyList<Product>> GetProductsAsync(int offset, int limit);

        Task<IReadOnlyList<Product>> GetProductsAsync(long[] ids);
    }
}
