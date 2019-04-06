using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories
{
    public interface IColumnRepository
    {
        Task<IEnumerable<Column>> ListAsync();
        Task AddAsync(Column column);
        Task<Column> FindByIdAsync(int id);
	    void Update(Column column);
        void Remove(Column column);
    }
}

