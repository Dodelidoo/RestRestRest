using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.API.Domain.Models
{
    [Table("batteries")]
    public class Battery
    {
        public int id { get; set; }
        public int building_id { get; set; }

        public string status { get; set; }



    }
}