using Proyecto_NET.Data.Entities;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_NET.Service;

namespace Proyecto_NET.Repositories
{
    internal interface iProductRepository
    {
        List<Product> getProducts();

        List<Product> getFilteredProducts(QueryFilter filter);

    }
}
