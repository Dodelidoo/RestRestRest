using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.API.Resources
{
    public class SaveBatteryResource
    {
        [Required]
        [MaxLength(32)]
        // public string Name { get; set; }

        public int id { get; set; }
        public int building_id { get; set; }
        public string status { get; set; }
    }
}
