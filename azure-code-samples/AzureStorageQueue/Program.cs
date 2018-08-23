using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string storageAccountConnStr = ConfigurationManager.AppSettings["storageAccountConnStr"];

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageAccountConnStr);

            CloudQueueClient cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();
           // AddMessageIntoQueue(cloudQueueClient);
            ReadMessagesPeek(cloudQueueClient);
            Console.ReadLine();
        }

        static void AddMessageIntoQueue(CloudQueueClient cloudQueueClient)
        {
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("queue1");
            cloudQueue.CreateIfNotExists();

            CloudQueueMessage msg = new CloudQueueMessage("This is fisrt message into queue");
            cloudQueue.AddMessage(msg);
        }

        static void ReadMessagesPeek(CloudQueueClient cloudQueueClient)
        {
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("queue1");
            cloudQueue.CreateIfNotExists();

            CloudQueueMessage msg = cloudQueue.PeekMessage();
            Console.WriteLine(msg.AsString);
        }

        static void ReadMessagesGet(CloudQueueClient cloudQueueClient)
        {
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("queue1");
            cloudQueue.CreateIfNotExists();

            CloudQueueMessage msg = cloudQueue.GetMessage();
            Console.WriteLine(msg.AsString);
        }
    }
}
