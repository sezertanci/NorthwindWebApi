using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Region : IEntity
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
    }
}
