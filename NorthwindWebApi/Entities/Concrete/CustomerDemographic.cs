using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class CustomerDemographic : IEntity
    {
        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }
    }
}
