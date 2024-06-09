using Proyecto_NET.Data;
using Proyecto_NET.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto_NET.Controllers
{
    public class ProductsApiController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<Product> Get()
        public IHttpActionResult Get()
        {
            using (var ctx = new AdventureWorksLT2022())
            {

                var query = from p in ctx.Products
                            orderby p.ProductID
                            select new {
                                p.ProductID,
                                p.Name,
                                p.ProductNumber,
                                p.Color,
                                p.StandardCost
                            };

                var resultados = query.ToList();
                return Ok(resultados);
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