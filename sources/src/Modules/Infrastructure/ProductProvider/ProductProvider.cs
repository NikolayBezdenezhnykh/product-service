using Confluent.Kafka;
using Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using SharpCompress.Compressors.Xz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ProductProvider
{
    public class ProductProvider : IProductProvider
    {
        private const string _dataBase = "product-service";
        private const string _collectionName = "Product";


        private readonly MongoClient _mongoClient;

        public ProductProvider(MongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(int offset, int limit)
        {
            var db = _mongoClient.GetDatabase(_dataBase);
            var collection = db.GetCollection<Product>(_collectionName);

            var products = await collection.Find(new BsonDocument())
               .Skip(offset)
               .Limit(limit)
               .ToListAsync();

            return products;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(long [] ids)
        {
            var db = _mongoClient.GetDatabase(_dataBase);
            var collection = db.GetCollection<Product>(_collectionName);

            var filter = Builders<Product>.Filter.In(x => x.ProductId, ids);

            var products = await collection.Find(filter).ToListAsync();

            return products;
        }
    }
}
