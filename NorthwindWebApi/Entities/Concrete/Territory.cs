using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Territory : IEntity
    {
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }
    }
}
