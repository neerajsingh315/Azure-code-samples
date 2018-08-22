using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageTables
{
    public class CarEntity:TableEntity
    {
        public CarEntity()
        {

        }
        public CarEntity(int id, int year, string make, string model, string color)
        {
            this.UniqueID = id;
            this.Year = year;
            this.Make = make;
            this.Model = model;
            this.Color = color;
            this.PartitionKey = "car";
            this.RowKey = id.ToString();
        }
        public int UniqueID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }
}
