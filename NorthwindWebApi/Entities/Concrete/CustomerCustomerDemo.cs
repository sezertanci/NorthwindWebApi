using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class CustomerCustomerDemo : IEntity
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }
    }
}
