
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderVM
    {
        //////Order table
        public int OrderID { get; set; }
        public DateTime OrderPlaceDate { get; set; }
        public DateTime DelevaryDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDelevered { get; set; }
        public string UserId { get; set; }

        //////Order Datails table
        public int OrderDetailsID { get; set; }
        public int UnitQuantity { get; set; }
        public double perUnitSellingPrice { get; set; }
        //public int? OrderID { get; set; }
        public int? ProductID { get; set; }

        ///////Shipling Address
        public int OSAID { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        //public int OrderID { get; set; }

        //////Payment

        public int PaymentID { get; set; }
        public string TransID { get; set; }
        public double Amount { get; set; }


        //public int? OrderID { get; set; }

        public int? PaymentTypeID { get; set; }
    }
}
