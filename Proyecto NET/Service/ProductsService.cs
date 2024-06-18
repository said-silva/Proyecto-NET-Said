using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Proyecto_NET.Data.Entities;
using Proyecto_NET.Domain.DTOs;
using Proyecto_NET.Repositories;
using Proyecto_NET.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace Proyecto_NET.Service
{
    public class ProductsService : iProductsService
    {
        
        private readonly ProductRepository _productRepository;

        public ProductsService() {
            _productRepository = new ProductRepository();
        }

        public List<ProductDTO> getProducts(string filter)
        {
            List<Product> products = new List<Product>();
            try
            {
                if (filter == null)
                {
                     products = _productRepository.getProducts();
                }
                else
                {

                    var filterObj = JsonConvert.DeserializeObject<QueryFilter>(filter);
                    var jsonObject = JObject.Parse(filter);
                    var filterDictionary = jsonObject.ToObject<Dictionary<string, object>>();
                    filterDictionary.Remove("orderBy");

                    var expression = createExpressionFilter(filterDictionary);

                    products = _productRepository.getFilteredProducts(expression, filterObj.orderBy);
                }

                var productsDTO = from p in products
                                               select new ProductDTO(){
                                                   name = p.Name,
                                                   productID = p.ProductID,
                                                   color = p.Color,
                                                   listPrice = p.ListPrice,
                                                   productNumber = p.ProductNumber,
                                               };
                return productsDTO.ToList();

            }
            catch (JsonReaderException e) {
                throw new Exception("Couldn't deserialize params");
            };
        }

        public bool deleteProduct(int id)
        {
            bool response = _productRepository.deleteProduct(id);
            return response;
        }

        public Product addProduct(Product product)
        {
            return _productRepository.addProduct(product);
        }

        public Product updateProduct(Product product) {
            return _productRepository.updateProduct(product);
        }

        public Product updateFields(int id, Product product) { 
            return _productRepository.updateProductFields(id, product);
        }


        public static Expression<Func<Product, bool>> createExpressionFilter(IDictionary<string, object> filters)
        {
            var param = Expression.Parameter(typeof(Product), "p");
            Expression body = null;

            foreach (var pair in filters)
            {
                var member = Expression.Property(param, pair.Key);

                Expression constant;

                Expression expression;

                if (pair.Value is JObject) {
                    var amountFilterObj = JsonConvert.DeserializeObject<PriceFilter>(pair.Value.ToString());

                    constant = Expression.Constant(amountFilterObj.value);
                    switch (amountFilterObj.operatorValue)
                    {
                        case "eq":
                            expression = Expression.Equal(member, constant);
                            break;
                        case "gt":
                            expression = Expression.GreaterThan(member, constant);
                            break;
                        case "lt":
                            expression = Expression.LessThan(member, constant);
                            break;
                        default:
                            throw new Exception("Couldn't recognize price filter operator");
                    }

                }
                else
                {
                    var constantValue = pair.Value is long ? Convert.ToInt32(pair.Value) : pair.Value;
                    constant = Expression.Constant(constantValue);
                    expression = Expression.Equal(member, constant);
                }

                body = body == null ? expression : Expression.AndAlso(body, expression);
            }
            return Expression.Lambda<Func<Product, bool>>(body, param);
        }
    }
}