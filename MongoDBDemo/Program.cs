using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDBDemo
{
    // SQL is more efficient in storing information, but No SQL sacrifices this for speed in querying
    class Program
    {
        static void Main(string[] args)
        {
            // if not available it will actually create one!  Can't do this in SQL.
            MongoCRUD db = new MongoCRUD("AddressBook");

            var oneRecord = db.LoadRecordById<PersonModel>("Users", new Guid("f33c2b5e-4eaf-4b4f-b1f6-d3b257ea30a3"));
            oneRecord.DateOfBirth = new DateTime(1982, 10, 31, 0, 0, 0, DateTimeKind.Utc);
            db.UpsertRecord("Users", oneRecord.Id, oneRecord);

            Console.ReadLine();
        }
    }

    public class MongoCRUD
    {
        private IMongoDatabase db;

        #region Constructors
        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            // 1st option connects to local Mongo so we need no arguments
            // 2nd onwards is where we would use a connection string e.g. 37.157.245.43 ... or to even connect to Mongo clusters

            db = client.GetDatabase(database);
        }
        #endregion

        // CRUD
        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table); // T will be some form of converted Json model
            collection.InsertOne(record);
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }

        public void UpsertRecord<T>(string table, Guid id, T record)
        {
            // UPSERT refers to, if it doesn't exist it will insert it, otherwise it will update it
            var collection = db.GetCollection<T>(table);

            var result = collection.ReplaceOne(new BsonDocument("_id", id), record, new UpdateOptions { IsUpsert = true });
        }

        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("id", id);
            collection.DeleteOne(filter);
        }
    }
}
