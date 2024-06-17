using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_NET.Domain.DTOs
{
    public class ProductDTO
    {
        public string name {  get; set; }
        public int productID { get; set; }
        public string color { get; set; }
        public decimal listPrice { get; set; }
        public string productNumber { get; set; }
    }

}