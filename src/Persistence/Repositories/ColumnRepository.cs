using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System;

namespace Supermarket.API.Persistence.Repositories
{
    public class ColumnRepository : BaseRepository, IColumnRepository
    {


        public ColumnRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Column>> ListAsync()
        {
            return await _context.Columns.ToListAsync();
        }

        public async Task AddAsync(Column column)
	    {
		    await _context.Columns.AddAsync(column);
	    }

        public async Task<Column> FindByIdAsync(int id)
        {
            return await _context.Columns.FindAsync(id);
        }

        public void Update(Column column)
        {
            Console.WriteLine(column.status);
            Console.WriteLine("^--Updated Column Info");
            Console.WriteLine();

            _context.Entry(column).State = EntityState.Modified;
            var recordsUpdated = _context.Columns.Update(column);

            recordsUpdated.Context.SaveChanges();
        }

        public void Remove(Column column)
        {
            _context.Columns.Remove(column);
        }
    }
}