using Proyecto_NET.Data.Entities;
using System.Collections.Generic;
using Proyecto_NET.Utilities;

namespace Proyecto_NET.Repositories
{
    internal interface iProductRepository
    {
        List<Product> getProducts();

        List<Product> getFilteredProducts(QueryFilter filter);

    }
}
