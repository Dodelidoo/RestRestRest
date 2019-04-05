using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services.Communication;
using Supermarket.API.Domain.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.API.Services
{
    public class BatteryService : IBatteryService
    {
        private readonly IBatteryRepository _batteryRepository;
        

        public BatteryService(IBatteryRepository batteryRepository)
        {
            _batteryRepository = batteryRepository;
            
        }

        public async Task<IEnumerable<Battery>> ListAsync()
        { 
           

            return await _batteryRepository.ListAsync();
            
        }

        public async Task<BatteryResponse> SaveAsync(Battery battery)
	{
		try
		{
			await _batteryRepository.AddAsync(battery);
			
			
			return new BatteryResponse(battery);
		}
		catch (Exception ex)
		{
			// Do some logging stuff
			return new BatteryResponse($"An error occurred when saving the battery: {ex.Message}");
		}
	}

        public async Task<BatteryResponse> UpdateAsync(int id, Battery battery)
        {
            var existingBattery = await _batteryRepository.FindByIdAsync(id);

            if (existingBattery == null)
                return new BatteryResponse("Battery not found.");

            existingBattery.id = battery.id;
            

            try
            {
                _batteryRepository.Update(existingBattery);
               

                return new BatteryResponse(existingBattery);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BatteryResponse($"An error occurred when updating the battery: {ex.Message}");
            }
        }

        public async Task<BatteryResponse> DeleteAsync(int id)
        {
            var existingBattery = await _batteryRepository.FindByIdAsync(id);

            if (existingBattery == null)
                return new BatteryResponse("Battery not found.");

            try
            {
                _batteryRepository.Remove(existingBattery);
                

                return new BatteryResponse(existingBattery);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BatteryResponse($"An error occurred when deleting the battery: {ex.Message}");
            }
        }
        

    }
}