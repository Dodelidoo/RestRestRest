using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System;

namespace Supermarket.API.Persistence.Repositories
{
    public class BatteryRepository : BaseRepository, IBatteryRepository
    {


        public BatteryRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Battery>> ListAsync()
        {
            return await _context.Batteries.ToListAsync();
        }

        public async Task AddAsync(Battery battery)
	    {
		    await _context.Batteries.AddAsync(battery);
	    }

        public async Task<Battery> FindByIdAsync(int id)
        {
            return await _context.Batteries.FindAsync(id);
        }

        public void Update(Battery battery)
        {
            Console.WriteLine(battery.status);
            Console.WriteLine("^--Update Battery");
            Console.WriteLine();

            _context.Entry(battery).State = EntityState.Modified;
            var recordsUpdated = _context.Batteries.Update(battery);

            Console.WriteLine("^--Records Updated");
            Console.WriteLine();

            recordsUpdated.Context.SaveChanges();
        }

        public void Remove(Battery battery)
        {
            _context.Batteries.Remove(battery);
        }
    }
}