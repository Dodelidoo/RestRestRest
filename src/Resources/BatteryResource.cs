using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Supermarket.API.Resources
{
    public class SaveBatteryResource
    {
        public int id { get; set; }

        public string status { get; set; }

    }
}


namespace Supermarket.API.Resources
{
    public class BatteryResource
    {
   

        public int id { get; set; }
        
        public string status { get; set; }
    }

}

namespace Supermarket.API.Resources
{
    public class ColumnResource
    {
   

        public int id { get; set; }
        
        public string status { get; set; }
        public BatteryResource Battery { get;set; }
    }

}