using Proyecto_NET.Data;
using Proyecto_NET.Data.Entities;
using Proyecto_NET.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

                var query = from p in ctx.Products
                            where p.Color.Equals(filter.color)
                            orderby filter.orderBy
                            select p;

                var resultados = query.ToList();
                return resultados;

                //IQueryable<Product> products = query;
                //var productsOver25 = products.Where(p => p.ListPrice >= 25);
            }

        }
    }
}