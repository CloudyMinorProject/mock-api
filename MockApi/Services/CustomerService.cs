using System.Collections.Generic;
using System.Linq;
using MockApi.Models;

namespace MockApi.Services
{

    public class CustomerService
    {
        private readonly List<Customer> _customers = new();
        private readonly object _lock = new();

        public CustomerService()
        {
            Seed();
        }

        private void Seed()
        {
            _customers.AddRange(new[]
            {
                new Customer
                {
                    CustomerID = 1,
                    DealerID = 100,
                    CustomerNr = "CUST-001",
                    Name = "Acme Corp",
                    Email = "info@acme.example",
                    Address = "1 Acme Way",
                    Phone = "+1-555-0100",
                    Active = 1
                },
                new Customer
                {
                    CustomerID = 2,
                    DealerID = 101,
                    CustomerNr = "CUST-002",
                    Name = "Contoso LLC",
                    Email = "sales@contoso.example",
                    Address = "42 Contoso Blvd",
                    Phone = "+1-555-0101",
                    Active = 1
                }
            });
        }

        private int NextId()
        {
            lock (_lock)
            {
                return _customers.Count == 0 ? 1 : _customers.Max(c => c.CustomerID) + 1;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            // Return a copy to avoid accidental outside mutation
            lock (_lock) { return _customers.Select(c => c).ToList(); }
        }

        public Customer? GetById(int id)
        {
            lock (_lock) { return _customers.FirstOrDefault(c => c.CustomerID == id); }
        }

        public Customer Create(Customer customer)
        {
            lock (_lock)
            {
                customer.CustomerID = NextId();
                _customers.Add(customer);
                return customer;
            }
        }

        public bool Update(int id, Customer customer)
        {
            lock (_lock)
            {
                var existing = _customers.FirstOrDefault(c => c.CustomerID == id);
                if (existing == null) return false;

                existing.DealerID = customer.DealerID;
                existing.CustomerNr = customer.CustomerNr;
                existing.Name = customer.Name;
                existing.Email = customer.Email;
                existing.Address = customer.Address;
                existing.Phone = customer.Phone;
                existing.Active = customer.Active;

                return true;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var existing = _customers.FirstOrDefault(c => c.CustomerID == id);
                if (existing == null) return false;
                _customers.Remove(existing);
                return true;
            }
        }
    }
}
