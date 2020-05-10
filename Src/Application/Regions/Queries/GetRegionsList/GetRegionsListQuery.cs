using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Regions.Queries.GetRegionsList
{
    public class GetRegionsListQuery : IRequest<RegionsListVm>
    {
    }

    public class GetCustomersListQueryHandler : IRequestHandler<GetRegionsListQuery, RegionsListVm>
    {
        private readonly INorthwindDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(INorthwindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RegionsListVm> Handle(GetRegionsListQuery request, CancellationToken cancellationToken)
        {
            var regions = await _context.Region
                .ProjectTo<RegionDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new RegionsListVm
            {
                Regions = regions
            };

            return vm;
        }
    }
}
