using System;

namespace MockApi.Models
{
  
    public class Customer
    {
        /// Local primary key for customers table.
        public int CustomerID { get; set; }

        /// Local foreign key for dealer ID.
        public int DealerID { get; set; }

        /// Unique identifier for the customer. Operator controlled.
        public string? CustomerNr { get; set; }

        /// Name of the customer.
        public string? Name { get; set; }

        /// Email of the customer.
        public string? Email { get; set; }

        /// Address of the customer.
        public string? Address { get; set; }

        /// Phone number of the customer.
        public string? Phone { get; set; }

        /// Whether the customer is active (1) or not (0). Stored as int to match XML content.
        public int Active { get; set; }
    }
}
