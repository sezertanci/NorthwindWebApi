using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Shipper : IEntity
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
