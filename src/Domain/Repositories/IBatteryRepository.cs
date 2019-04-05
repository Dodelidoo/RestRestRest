using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories
{
    public interface IBatteryRepository
    {
        Task<IEnumerable<Battery>> ListAsync();
        Task AddAsync(Battery battery);
        Task<Battery> FindByIdAsync(int id);
	    void Update(Battery battery);
        void Remove(Battery battery);
    }
}

