
using Task.Domain.Entites;

namespace Task.Domain.Lookups
{
    public class Region : BaseLookup
    {
        public Region()
        {
            Contracts = new HashSet<Contracts>();
            Cities = new HashSet<City>();
        }
        public ICollection<Contracts> Contracts { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
