using Proyecto_NET.Data.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Proyecto_NET.Repositories
{
    internal interface iProductRepository
    {
        List<Product> getProducts();

        List<Product> getFilteredProducts(Expression<Func<Product, bool>> filter, string orderBy);

        bool deleteProduct(int id);

        Product addProduct(Product product);

        Product updateProductFields(int id, Product product);
    }
}
