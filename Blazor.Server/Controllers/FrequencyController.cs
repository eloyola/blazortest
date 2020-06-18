using Beam.Shared;
using Blazor.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared = Beam.Shared;
using Blazor.Server.Mapper;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequencyController : ControllerBase
    {
        BeamContext _context;
        public FrequencyController(BeamContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public List<Shared.Frequency> All()
        {
            return _context.Frequencies.Select(r => r.ToShared()).ToList();
        }

        [HttpPost("[action]")]
        public List<Shared.Frequency> Add([FromBody] Shared.Frequency frequency)
        {
            _context.Add(new Blazor.Data.Models.Frequency() { Name = frequency.Name });
            _context.SaveChanges();
            return _context.Frequencies.Select(r => r.ToShared()).ToList();
        }

    }
}