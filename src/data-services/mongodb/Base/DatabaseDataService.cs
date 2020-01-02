using DataServices.MongoDB.Base.DataObjects;
using MongoDB.Driver;

namespace DataServices.MongoDB.Base
{
    public abstract class DatabaseDataService : IDatabaseDataService
    {
        protected IMongoDatabase Database;

        protected DatabaseDataService(IDatabaseObject database, IDatabaseCollectionObject databaseCollection)
        {
            var client = new MongoClient(@"mongodb://root:example@host.docker.internal:27017");
            Database = client.GetDatabase(database.Name);
            Collection = databaseCollection;
        }

        protected DatabaseDataService(IMongoDatabase database)
        {
            Database = database;
        }

        public IDatabaseCollectionObject Collection { get; }
    }
}