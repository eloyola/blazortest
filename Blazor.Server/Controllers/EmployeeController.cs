using Beam.Shared;
using Blazor.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared = Beam.Shared;
using Blazor.Server.Mapper;
using Beam.Shared.Model;

namespace Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeContext _context;
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public List<Employee> All()
        {
            return _context.tblEmployee.ToList();
        }
    }
}