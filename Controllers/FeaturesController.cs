using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcore_spa.Controllers.Resources;
using aspnetcore_spa.Models;
using aspnetcore_spa.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_spa.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FeaturesController(ApplicationDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;

        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await _context.Features.ToListAsync();

            return _mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}