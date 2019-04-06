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
    public class ColumnService : IColumnService
    {
        private readonly IColumnRepository _columnRepository;
        

        public ColumnService(IColumnRepository columnRepository)
        {
            
            _columnRepository = columnRepository;
            
        }

        public async Task<IEnumerable<Column>> ListAsync()
        { 
           

            return await _columnRepository.ListAsync();
            
        }

        public async Task<ColumnResponse> SaveAsync(Column column)
	{
		try
		{
			await _columnRepository.AddAsync(column);
			
			
			return new ColumnResponse(column);
		}
		catch (Exception ex)
		{
			// Do some logging stuff
			return new ColumnResponse($"An error occurred when saving the column: {ex.Message}");
		}
	}

        public async Task<ColumnResponse> UpdateAsync(int id, Column column)
        {
            var existingColumn = await _columnRepository.FindByIdAsync(id);

            Console.WriteLine(column);
            Console.WriteLine(id);
            Console.WriteLine("^--Column Update Async Method");
            Console.WriteLine();

            if (existingColumn == null)
                return new ColumnResponse("column not found.");

            existingColumn.id = column.id;
            existingColumn.status = column.status;


            try
            {

                _columnRepository.Update(existingColumn);
            
                return new ColumnResponse(existingColumn);
            }

            catch (Exception ex)
            {
                
                // Do some logging stuff
                return new ColumnResponse($"An error occurred when updating the column: {ex.Message}");
            }
        }

        public async Task<ColumnResponse> DeleteAsync(int id)
        {
            var existingColumn = await _columnRepository.FindByIdAsync(id);

            if (existingColumn == null)
                return new ColumnResponse("Column not found.");

            try
            {
                _columnRepository.Remove(existingColumn);
                

                return new ColumnResponse(existingColumn);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ColumnResponse($"An error occurred when deleting the column: {ex.Message}");
            }
        }
        

    }
}