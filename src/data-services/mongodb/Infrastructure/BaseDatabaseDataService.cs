using DataServices.MongoDB.Base;
using DataServices.MongoDB.Base.DataObjects;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataServices.MongoDB.Infrastructure
{
    public class BaseDatabaseDataService : DatabaseDataService
    {
        public BaseDatabaseDataService(IDatabaseObject database, IDatabaseCollectionObject databaseCollection) : base(
            database, databaseCollection)
        {
        }

        public BaseDatabaseDataService(IMongoDatabase database) : base(database)
        {
        }

        public void BadInsert()
        {
            var document = new BsonDocument
            {
                {"student_id", 10000},
                {
                    "scores",
                    new BsonArray
                    {
                        new BsonDocument {{"type", "exam"}, {"score", 88.12334193287023}},
                        new BsonDocument {{"type", "quiz"}, {"score", 74.92381029342834}},
                        new BsonDocument {{"type", "homework"}, {"score", 89.97929384290324}},
                        new BsonDocument {{"type", "homework"}, {"score", 82.12931030513218}}
                    }
                },
                {"class_id", 480}
            };
            var col = Database.GetCollection<BsonDocument>("tmp");
            col.InsertOne(document);
        }
    }
}