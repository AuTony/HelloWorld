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
            //_collection.Find(new BsonDocument()).ForEachAsync(d => Console.WriteLine(d));
            // find record
            var doc = _collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(doc.ToString());
            Console.WriteLine("====================================================================");
            // find a specific record
            var _filter = Builders<BsonDocument>.Filter.Eq("restaurant_id", "40356151");
            doc = _collection.Find(_filter).First();
            Console.WriteLine(doc.ToString());
            Console.WriteLine("====================================================================");
            // find specific record sets
            _filter = Builders<BsonDocument>.Filter.Gt("grades.score", 38);
            _collection.Find(_filter).ForEachAsync(d => Console.WriteLine(d));            
            Console.WriteLine("====================================================================");
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
