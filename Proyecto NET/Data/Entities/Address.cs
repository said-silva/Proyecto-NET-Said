namespace Proyecto_NET.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        public int AddressID { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public string CountryRegion { get; set; }

        public string PostalCode { get; set; }

        public string rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
