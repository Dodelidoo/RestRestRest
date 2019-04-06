using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.API.Domain.Models
{
    [Table("batteries")]
    public class Battery
    {
        public int id { get; set; }
        public string status { get; set; }

        public IList<Column> Column { get; set; } = new List<Column>();

    }
}