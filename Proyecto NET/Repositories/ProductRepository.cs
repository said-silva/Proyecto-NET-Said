using Proyecto_NET.Data;
using Proyecto_NET.Data.Entities;
using Proyecto_NET.Service;
using System.Collections.Generic;
using System.Linq;

using ExtensionMethods;
namespace Proyecto_NET.Repositories
{
    public class ProductRepository : iProductRepository
    {
        public List<Product> getProducts()
        {
            using (var ctx = new AdventureWorksLT2022())
            {

                var query = from p in ctx.Products
                            orderby p.ProductID
                            select p;

                var resultados = query.ToList();
                return resultados;
            }
        }
        public List<Product> getFilteredProducts(QueryFilter filter)
        {
            using (var ctx = new AdventureWorksLT2022())
            {
                var products = ctx.Products.AsQueryable();
                if (filter.productNumber != null)
                {
                    products = products.Where(p => p.ProductID.Equals(filter.productId));
                }
                if (filter.name != null)
                {
                    products = products.Where(p => p.Name.Equals(filter.name));
                }
                if (filter.productNumber != null)
                {
                    products = products.Where(p => p.ProductNumber.Equals(filter.productNumber));
                }
                if (filter.color != null)
                {
                    products = products.Where(p => p.Color.Equals(filter.color));
                }
                if (filter.priceFilter != null)
                {
                    switch (filter.priceFilter.operatorValue)
                    {
                        case "eq":
                            products = products.Where(p => p.ListPrice == filter.priceFilter.value);
                            break;
                        case "gt":
                            products = products.Where(p => p.ListPrice >= filter.priceFilter.value);
                            break;
                        case "lt":
                            products = products.Where(p => p.ListPrice <= filter.priceFilter.value);
                            break;
                        default:
                            throw new System.Exception("Couldn't recognize price filter operator");
                    }
                }

                if (filter.orderBy != null)
                {
                    products = products.OrderBy(filter.orderBy);
                }
                


                return products.ToList();

            }

        }

        
    }
}