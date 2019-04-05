
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
            foreach(var i in batteries)
            {
             Console.WriteLine(i.id);
             Console.WriteLine(i.status);
            }
            var resources = _mapper.Map<IEnumerable<Battery>, IEnumerable<BatteryResource>>(batteries);
            Console.WriteLine("^--Get List");
            
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
            

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            Console.WriteLine(id);
            Console.WriteLine("^--Put Id");

            var battery = _mapper.Map<SaveBatteryResource, Battery>(resource);

            Console.WriteLine(resource.status);
            Console.WriteLine("^--Resource Controller Status");
            Console.WriteLine();
            Console.WriteLine(battery);
            Console.WriteLine("^--Battery Controller");
            Console.WriteLine();

            var result = await _batteryService.UpdateAsync(id , battery);


            if (!result.Success)
                return BadRequest(result.Message);

              
            var batteryResource = _mapper.Map<Battery, BatteryResource>(result.Battery);

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
