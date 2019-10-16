using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutors.Dao.Abstract;
using Tutors.Domain;

namespace Tutors.Dao.Mongo
{
    public class MongoPupilDao : IPupilDao
    {
        IMongoDatabase database;

        static MongoPupilDao()
        {
            BsonClassMap.RegisterClassMap<Pupil>(cm =>
            {
                cm.AutoMap();
                cm.IdMemberMap.SetIdGenerator(new IntIdGenerator("tutor_identity"));
                cm.MapMember(c => c.PriceList).SetSerializer(new DictionaryInterfaceImplementerSerializer<Dictionary<LessonDuration, decimal>>(DictionaryRepresentation.ArrayOfArrays));
            });
            //ConventionRegistry.Register(
            //   "DictionaryRepresentationConvention",
            //   new ConventionPack { new DictionaryRepresentationConvention(DictionaryRepresentation.ArrayOfArrays) },
            //   _ => true);
        }

        public MongoPupilDao(string connectionString)
        {
            var client = new MongoClient(connectionString);                                  
            database = client.GetDatabase("tutors");
        }

        private IMongoCollection<Pupil> GetCollection() => database.GetCollection<Pupil>("tutor");

        public Task<Pupil> AddExtraLesson(int pupilId, ExtraLesson extraLesson)
        {
            throw new NotImplementedException();
        }

        public async Task<Pupil> DeletePupil(int id)
        {
            var collection = GetCollection();
            var filter = Builders<Pupil>.Filter.Where(p => p.Id == id);
            var result = await collection.Find(filter).FirstAsync();
            await collection.DeleteOneAsync(filter);
            return result;
        }

        public async Task<Pupil> GetPupil(int id)
        {
            var collection = GetCollection();
            var filter = Builders<Pupil>.Filter.Where(p => p.Id == id);
            return await collection.Find(filter).FirstAsync();
        }

        public async Task<List<Pupil>> GetPupils(int userId)
        {
            var collection = GetCollection();
            var filter = Builders<Pupil>.Filter.Where(p => p.UserId == userId);
            return await collection.Find(filter).ToListAsync();
        }

        public async Task<Pupil> SavePupil(Pupil pupil)
        {
            var collection = GetCollection();
            if (pupil.Id == 0)
            {
                await collection.InsertOneAsync(pupil);
                return pupil;
            }
           
            return await collection.FindOneAndReplaceAsync<Pupil>(Builders<Pupil>.Filter.Where(p => p.Id == pupil.Id),
                        pupil,
                        new FindOneAndReplaceOptions<Pupil, Pupil>()
                        {
                            ReturnDocument = ReturnDocument.After
                        });
        }
    }
}
