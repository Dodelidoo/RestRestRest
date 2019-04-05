
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;
using Supermarket.API.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class BatteriesController : Controller
    {
         private readonly IBatteryService _batteryService;
        
         private readonly IMapper _mapper;
        public BatteriesController(IBatteryService batteryService, IMapper mapper)
        {
            _batteryService = batteryService;
            _mapper = mapper;
            
        }
        
        [HttpGet]
        public async Task<IEnumerable<BatteryResource>> GetAllAsync()
        {
            
            var batteries = await _batteryService.ListAsync();
            Console.WriteLine("c1");
            foreach(var i in batteries)
            {
             Console.WriteLine(i.id);
             Console.WriteLine(i.status);
            }
            Console.WriteLine("c2");
            var resources = _mapper.Map<IEnumerable<Battery>, IEnumerable<BatteryResource>>(batteries);
            Console.WriteLine("c3");
            
            return resources;
        }
    

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBatteryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var battery = _mapper.Map<SaveBatteryResource, Battery>(resource);
            var result = await _batteryService.SaveAsync(battery);

            if (!result.Success)
                return BadRequest(result.Message);

            var batteryResource = _mapper.Map<Battery, BatteryResource>(result.Battery);
            return Ok(batteryResource);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBatteryResource resource)
        {
            Console.WriteLine("bat1");
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

                Console.WriteLine("bat2");

            var battery = _mapper.Map<SaveBatteryResource, Battery>(resource);
            var result = await _batteryService.UpdateAsync(id, battery);

            Console.WriteLine("bat3");

            if (!result.Success)
                return BadRequest(result.Message);

                Console.WriteLine("bat4");

            var batteryResource = _mapper.Map<Battery, BatteryResource>(result.Battery);

            Console.WriteLine("bat5");

            return Ok(batteryResource);

           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _batteryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var batteryResource = _mapper.Map<Battery, BatteryResource>(result.Battery);
            return Ok(batteryResource);
        }
    }
}
