using Proyecto_NET.Data.Entities;
using System.Collections.Generic;
using Proyecto_NET.Utilities;

namespace Proyecto_NET.Repositories
{
    internal interface iProductRepository
    {
        List<Product> getProducts();

        List<Product> getFilteredProducts(QueryFilter filter);

        bool deleteProduct(int id);

        Product addProduct(Product product);

        Product updateProduct(Product product);

        Product updateProductFields(int id, Product product);
    }
}
