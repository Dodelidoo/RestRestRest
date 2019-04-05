using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Supermarket.API.Resources
{
    public class BatteryResource
    {
    //    public int Id { get; set; }
    //    public string Name { get; set; }

        public int id { get; set; }
        public int building_id { get; set; }
        public string status { get; set; }
    }
        // public BatteryResource Battery {get;set;}
}

// namespace Supermarket.API.Resources
// {
//      public class ProductResource
//     {
//         public int id { get; set; }
//         public int building_id { get; set; }
//         public string status { get; set; }
//         public BatteryResource Battery {get;set;}
//     }

// }