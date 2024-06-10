using Proyecto_NET.Data;
using Proyecto_NET.Data.Entities;
using Proyecto_NET.Service;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

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

                if (filter.orderBy != null)
                {
                    products = products.OrderBy(filter.orderBy);
                }

                return products.ToList();

            }

        }

        
    }
}