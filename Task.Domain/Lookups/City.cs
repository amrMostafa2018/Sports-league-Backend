
using Task.Domain.Entites;

namespace Task.Domain.Lookups
{
    public class City : BaseLookup
    {
        public City()
        {
            Contracts = new HashSet<Contracts>();
        }
        public int? RegionId { get; set; }
        public virtual Region? Region { get; set; }
        public ICollection<Contracts> Contracts { get; set; }
    }
}
