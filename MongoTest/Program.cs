using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var _client = new MongoClient("mongodb://52.62.60.102:27017");
            var _db = _client.GetDatabase("test");
            var _collection = _db.GetCollection<BsonDocument>("restaurants");
            // get record count from database
            var count = _collection.Count(new BsonDocument());
            // pull down everything from database by using async method
            _collection.Find(new BsonDocument()).ForEachAsync(d => Console.WriteLine(d));
            // update record

            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
