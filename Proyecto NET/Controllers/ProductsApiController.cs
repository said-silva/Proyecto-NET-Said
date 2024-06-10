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
        // GET api/<controller>
        public IHttpActionResult Get(string filter = null)
        {
            try
            {
                var productService = new ProductsService();
                List<Product> resp = productService.getProducts(filter);

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

                //return Ok(resp);

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