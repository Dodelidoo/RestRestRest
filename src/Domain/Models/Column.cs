using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.API.Domain.Models
{
    [Table("columns")]
    public class Column
    {
        public int id { get; set; }
        public string status { get; set; }

        public Battery Battery { get; set; }
        
    }
}
    // public int BatteryId { get; set; }