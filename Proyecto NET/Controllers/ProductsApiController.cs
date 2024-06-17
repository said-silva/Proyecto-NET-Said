using Proyecto_NET.Data.Entities;
using Proyecto_NET.Service;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Http;
using Proyecto_NET.Utilities;
using Proyecto_NET.Domain.DTOs;

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
                List<ProductDTO> resp = _productService.getProducts(filter);

                return Ok(resp);



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
        //public void Put(int id, [FromBody] string value)
        // Update using only some fields (To be determined by the UI)
        public IHttpActionResult Put(int id, Product product)
        {

            return Ok(_productService.updateFields(id, product));
        }

        // Update using all the object
        public IHttpActionResult Patch(Product product)
        {

            return Ok(_productService.updateProduct(product));
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                bool resp = _productService.deleteProduct(id);
                if (resp)
                    return Ok();
                else return BadRequest("El recurso especificado no existe");
            } catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}