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
    public class MakesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MakesController(ApplicationDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;

        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        //public async Task<IActionResult> GetMakes()
        {
            var makes = await _context.Makes.Include(m => m.Models).ToListAsync();
            var makesDto = _mapper.Map<List<Make>,List<MakeResource>>(makes);
            return makesDto;//Ok(new { success = true, data = makesDto });
        }
    }
}