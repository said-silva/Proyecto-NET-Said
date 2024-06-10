using Proyecto_NET.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_NET.Service
{
    internal interface iProductsService
    {
        List<Product> getProducts(string filter);
    }
}
