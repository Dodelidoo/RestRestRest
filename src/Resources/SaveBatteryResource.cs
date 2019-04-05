using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Supermarket.API.Resources
{
    public class SaveBatteryResource
    {
        public int id { get; set; }

        public string status { get; set; }

    }
}
