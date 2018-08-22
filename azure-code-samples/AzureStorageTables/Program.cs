using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
namespace AzureStorageTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string storageAccountConnStr = ConfigurationManager.AppSettings["storageAccountConnStr"];

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageAccountConnStr);

            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();

            //CreateTable(cloudTableClient);
            //InsertData(cloudTableClient);
            //RetrieveData(cloudTableClient);
            QueryTable(cloudTableClient);
        }

        static void CreateTable(CloudTableClient cloudTableClient)
        {
            CloudTable cloudTable = cloudTableClient.GetTableReference("table1");
            cloudTable.CreateIfNotExists();
        }

        static void InsertData(CloudTableClient cloudTableClient)
        {
            CloudTable cloudTable = cloudTableClient.GetTableReference("table1");
            cloudTable.CreateIfNotExists();
            //CarEntity carEntity = new CarEntity(100, 2018, "Suzuki", "Ciaz", "Black");
            CarEntity carEntity = new CarEntity(101, 2018, "BMW", "X1", "Blue");
            TableOperation insert = TableOperation.Insert(carEntity);
            cloudTable.Execute(insert);
        }

        static void InsertDataWithTransaction(CloudTableClient cloudTableClient)
        {
            CloudTable cloudTable = cloudTableClient.GetTableReference("table1");
            cloudTable.CreateIfNotExists();
            TableBatchOperation tbo = new TableBatchOperation();
            CarEntity carEntity = new CarEntity(102, 2018, "Tata", "Safari", "Silver");
            tbo.Insert(carEntity);
            carEntity = new CarEntity(103, 2016, "Honda", "Civic", "White");
            tbo.Insert(carEntity);

            cloudTable.ExecuteBatch(tbo);

        }

        static void RetrieveData(CloudTableClient cloudTableClient)
        {
            CloudTable cloudTable = cloudTableClient.GetTableReference("table1");
            cloudTable.CreateIfNotExists();

            TableOperation retreive = TableOperation.Retrieve<CarEntity>("car", "100");
            TableResult res=cloudTable.Execute(retreive);
            if(res!=null)
            {
                Console.WriteLine("car details: "+((CarEntity)res.Result).Make+", "+ ((CarEntity)res.Result).Model);
            }
            Console.ReadLine();
        }

        static void QueryTable(CloudTableClient cloudTableClient)
        {
            CloudTable cloudTable = cloudTableClient.GetTableReference("table1");
            cloudTable.CreateIfNotExists();

            TableQuery<CarEntity> carQuery = new TableQuery<CarEntity>();
            foreach (CarEntity car in cloudTable.ExecuteQuery(carQuery))
            {
                Console.WriteLine("car details: " + car.Make + ", " + car.Model);
            }
            Console.ReadLine();
        }
    }
}
