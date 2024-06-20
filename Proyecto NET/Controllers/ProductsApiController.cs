using Proyecto_NET.Data.Entities;
using Proyecto_NET.Service;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Http;
using Proyecto_NET.Utilities;
using Proyecto_NET.Domain.DTOs;
using Newtonsoft.Json.Linq;

namespace Proyecto_NET.Controllers
{

    public class ProductsApiController : ApiController
    {
        private readonly iProductsService _productService;
        public ProductsApiController(iProductsService productsService) {
            _productService = productsService;
        }

        // GET api/<controller>
        public IHttpActionResult Get(string filter = null)
        {
            try
            {
                IDictionary<string, object> filterDictionary = null;

                string orderByColumn = null;

                if (filter != null)
                {
                    var jsonObject = JObject.Parse(filter);
                    filterDictionary = jsonObject.ToObject<Dictionary<string, object>>();
                    orderByColumn = filterDictionary["orderBy"].ToString();
                    filterDictionary.Remove("orderBy");
                }


                List<ProductDTO> resp = _productService.getProducts(filterDictionary, orderByColumn);

                return Ok(resp);
            } catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Check the body for errors");
                }
                return Ok(_productService.addProduct(product));
            }
            catch (Exception ex) {
                return InternalServerError(ex);
            }   
        }

        // PUT api/<controller>/5
        // Update using only some fields (To be determined by the UI)
        public IHttpActionResult Put(int id, Product product)
        {
            try {
                var response = _productService.updateFields(id, product);
                if (response is null)
                    return BadRequest("Couldn't find specified ID");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                bool resp = _productService.deleteProduct(id);
                if (resp)
                    return Ok();
                else return BadRequest("Couldn't find specified resource");
            } catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}