using System.Collections.Generic;
using System.Linq;
using MockApi.Models;

namespace MockApi.Services
{
    /// <summary>
    /// Simple in-memory Dealer service for mock API.
    /// </summary>
    public class DealerService
    {
        private readonly List<Dealer> _dealers = new();
        private readonly object _lock = new();

        public DealerService()
        {
            Seed();
        }

        private void Seed()
        {
            _dealers.AddRange(new[]
            {
                new Dealer { DealerID = 1, DealerNr = "DLR-001", Name = "North Supply", Address = "100 North St", Phone = "+1-555-1000", Active = 1 },
                new Dealer { DealerID = 2, DealerNr = "DLR-002", Name = "South Trading", Address = "200 South Ave", Phone = "+1-555-1001", Active = 1 },
            });
        }

        private int NextId()
        {
            lock (_lock)
            {
                return _dealers.Count == 0 ? 1 : _dealers.Max(d => d.DealerID) + 1;
            }
        }

        public IEnumerable<Dealer> GetAll()
        {
            lock (_lock) { return _dealers.Select(d => d).ToList(); }
        }

        public Dealer? GetById(int id)
        {
            lock (_lock) { return _dealers.FirstOrDefault(d => d.DealerID == id); }
        }

        public Dealer Create(Dealer dealer)
        {
            lock (_lock)
            {
                dealer.DealerID = NextId();
                _dealers.Add(dealer);
                return dealer;
            }
        }

        public bool Update(int id, Dealer dealer)
        {
            lock (_lock)
            {
                var existing = _dealers.FirstOrDefault(d => d.DealerID == id);
                if (existing == null) return false;

                existing.DealerNr = dealer.DealerNr;
                existing.Name = dealer.Name;
                existing.Address = dealer.Address;
                existing.Phone = dealer.Phone;
                existing.Active = dealer.Active;

                return true;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var existing = _dealers.FirstOrDefault(d => d.DealerID == id);
                if (existing == null) return false;
                _dealers.Remove(existing);
                return true;
            }
        }
    }
}
