using System;

namespace MockApi.Models
{
    /// <summary>
    /// Represents a Dealer as described in dealers.md
    /// </summary>
    public class Dealer
    {
        /// Local primary key for dealers table.
        public int DealerID { get; set; }

        /// Unique identifier for the dealer. Operator controlled.
        public string? DealerNr { get; set; }

        /// Name of the dealer.
        public string? Name { get; set; }

        /// Address of the dealer.
        public string? Address { get; set; }

        /// Phone number of the dealer.
        public string? Phone { get; set; }

        /// Whether the dealer is active (1) or not (0).
        public int Active { get; set; }

        /// Convenience: return boolean for Active
        public bool IsActive => Active == 1;
    }
}
