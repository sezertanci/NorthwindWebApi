using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class EmployeeTerritory : IEntity
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }
    }
}
