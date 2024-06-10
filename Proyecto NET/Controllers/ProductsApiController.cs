using Newtonsoft.Json;
using Proyecto_NET.Data;
using Proyecto_NET.Data.Entities;
using Proyecto_NET.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Proyecto_NET.Controllers
{
    public class ProductsApiController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get(string filter = null)
        {
            var productService = new ProductsService();
            var resp = productService.getProducts(filter);

            var customResponse = from cr in resp
                                 select new
                                 {
                                     cr.Name,
                                     cr.ProductID,
                                     cr.Color,
                                     cr.ListPrice,
                                 };

            return Ok(customResponse);
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