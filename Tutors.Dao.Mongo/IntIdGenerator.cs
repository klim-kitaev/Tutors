using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Dao.Mongo
{
    public class IntIdGenerator: IIdGenerator
    {
        private readonly string _idCollectionName;

        public IntIdGenerator(string idCollectionName)
        {
            _idCollectionName = idCollectionName;
        }


        public object GenerateId(object container, object document)
        {
            var idSequenceCollection = ((dynamic)container).Database.GetCollection<dynamic>(_idCollectionName);

            var query = Builders<dynamic>.Filter.Eq("_id", ((dynamic)container).CollectionNamespace.CollectionName);

            var update = Builders<dynamic>.Update.Inc("seq", 1);


            var bsonResult = ((IEnumerable<KeyValuePair<string, object>>)idSequenceCollection.FindOneAndUpdate(query, update, new FindOneAndUpdateOptions<dynamic> { ReturnDocument = ReturnDocument.After, IsUpsert = true })).ToBsonDocument();

            var result = bsonResult.GetValue("seq").ToInt32();

            return result;
        }

        public bool IsEmpty(object id)
        {
            return (int)id == 0;
        }
    }
}
