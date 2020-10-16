using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using MongoDB.Driver;

namespace Lab2DataStorage.Models
{
    public class MongoDBClass
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }

        public static string MongoConnection = "mongodb+srv://crud_user:crud_user@cluster0.jnodw.mongodb.net/<dbname>?retryWrites=true&w=majority";
        public static string MongoDatabase = "crud_mongodb";

        public static IMongoCollection<Models.Apartments> apartments_collection { get; set; }

        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}