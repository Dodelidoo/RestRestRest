using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class ColumnController : Controller
    {
        private readonly IColumnService _columnService;
        private readonly IMapper _mapper;

        public ColumnController(IColumnService columnService, IMapper mapper)
        {
            _columnService = columnService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ColumnResource>> ListAsync()
        {
            var column = await _columnService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Column>, IEnumerable<ColumnResource>>(column);
            return resources;
        }
    }
}