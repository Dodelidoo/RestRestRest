using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;


namespace Supermarket.API.Domain.Services
{
    public interface IBatteryService
    {
         Task<IEnumerable<Battery>> ListAsync();
         Task<BatteryResponse> SaveAsync(Battery battery);
         Task<BatteryResponse> UpdateAsync(int id, Battery battery);
         Task<BatteryResponse> DeleteAsync(int id);
    }
}