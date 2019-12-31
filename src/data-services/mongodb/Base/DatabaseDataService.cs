using DataServices.MongoDB.Base.DataObjects;
using MongoDB.Driver;

namespace DataServices.MongoDB.Base
{
    public abstract class DatabaseDataService : IDatabaseDataService
    {
        protected IMongoDatabase Database;

        protected DatabaseDataService(IDatabaseObject database, IDatabaseCollectionObject databaseCollection)
        {
            Database = new MongoClient().GetDatabase(database.Name);
            Collection = databaseCollection;
        }

        protected DatabaseDataService(IMongoDatabase database)
        {
            Database = database;
        }

        public IDatabaseCollectionObject Collection { get; }
    }
}