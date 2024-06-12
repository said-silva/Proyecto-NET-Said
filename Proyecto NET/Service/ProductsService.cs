using Newtonsoft.Json;
using Proyecto_NET.Data.Entities;
using Proyecto_NET.Repositories;
using Proyecto_NET.Utilities;
using System;
using System.Collections.Generic;

namespace Proyecto_NET.Service
{
    public class ProductsService : iProductsService
    {
        
        private readonly ProductRepository _productRepository;

        public ProductsService() {
            _productRepository = new ProductRepository();
        }

        public List<Product> getProducts(string filter)
        {
            try
            {
                if (filter == null)
                {
                    return _productRepository.getProducts();
                }
                QueryFilter filterObj = JsonConvert.DeserializeObject<QueryFilter>(filter);
                return _productRepository.getFilteredProducts(filterObj);

            }
            catch (JsonReaderException e) {
                throw new Exception("Couldn't deserialize params");
            };
        }
    }
}