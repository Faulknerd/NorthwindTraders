using Northwind.Application.Common.Mappings;
using Northwind.Domain.Entities;

namespace Northwind.Application.Regions.Queries.GetRegionsList
{
    public class RegionDto : IMapFrom<Region>
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
    }
}
