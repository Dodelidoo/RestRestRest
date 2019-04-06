using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;


namespace Supermarket.API.Domain.Services
{
    public interface IColumnService
    {
         Task<IEnumerable<Column>> ListAsync();
         Task<ColumnResponse> SaveAsync(Column column);
         Task<ColumnResponse> UpdateAsync(int id, Column column);
         Task<ColumnResponse> DeleteAsync(int id);
    }
}