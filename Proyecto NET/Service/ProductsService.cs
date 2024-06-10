using Newtonsoft.Json;
using Proyecto_NET.Data.Entities;
using Proyecto_NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_NET.Service
{
    public class ProductsService : iProductsService
    {
        public List<Product> getProducts(string filter)
        {
            var productRepository = new ProductRepository();
            try
            {
                if (filter == null)
                {
                    return productRepository.getProducts();
                }
                QueryFilter filterObj = JsonConvert.DeserializeObject<QueryFilter>(filter);
                return productRepository.getFilteredProducts(filterObj);

            }
            catch (JsonReaderException e) {
                throw new Exception("Couldn't deserialize params");
            }

            ;
        }
    }

    public class QueryFilter{
        public string color { get; set; }
        public string orderBy { get; set; }
    }
}