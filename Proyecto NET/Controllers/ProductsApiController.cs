using Proyecto_NET.Data.Entities;
using Proyecto_NET.Service;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Http;

namespace Proyecto_NET.Controllers
{
    public class ProductsApiController : ApiController
    {
        private readonly ProductsService _productService;
        public ProductsApiController() {
            _productService = new ProductsService();
        }

        // GET api/<controller>
        public IHttpActionResult Get(string filter = null)
        {
            try
            {
                List<Product> resp = _productService.getProducts(filter);

                // If you need all the attributes return after fetching the data
                //return Ok(resp);

                // If you want to use a custome version of the object with the most important attributes only
                var customResponse = from cr in resp
                                     select new
                                     {
                                         cr.Name,
                                         cr.ProductID,
                                         cr.Color,
                                         cr.ListPrice,
                                         cr.ProductNumber,
                                     };

                return Ok(customResponse);


            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}