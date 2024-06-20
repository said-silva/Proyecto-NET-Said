using Proyecto_NET.Data.Entities;
using Proyecto_NET.Domain.DTOs;
using System.Collections.Generic;

namespace Proyecto_NET.Service
{
    public interface iProductsService
    {
        List<ProductDTO> getProducts(IDictionary<string, object> filter, string orderByColumn);

        bool deleteProduct(int id);

        Product addProduct(Product product);

        Product updateFields(int id, Product product);

    }
}
