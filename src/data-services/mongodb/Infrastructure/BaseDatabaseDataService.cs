using System;
using System.Linq.Expressions;
using DataServices.MongoDB.Base;
using DataServices.MongoDB.Base.DataObjects;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DataServices.MongoDB.Infrastructure
{
    public class BaseDatabaseDataService<TDocument> : DatabaseDataService, IBaseDatabaseDataService<TDocument>
    {
        public BaseDatabaseDataService(IDatabaseObject database, IDatabaseCollectionObject databaseCollection) : base(
            database, databaseCollection)
        {
        }

        public BaseDatabaseDataService(IMongoDatabase database) : base(database)
        {
        }

        public IMongoCollection<TDocument> Documents => Database.GetCollection<TDocument>(Collection.Name);

        public virtual void Add(TDocument document)
        {
            Documents.InsertOne(document);
        }

        public virtual DeleteResult Remove(Expression<Func<TDocument, bool>> filter)
        {
            return Documents.DeleteOne(filter);
        }

        public virtual IMongoQueryable<TDocument> Find()
        {
            return Documents.AsQueryable();
        }

        public virtual IFindFluent<TDocument, TDocument> Find(Expression<Func<TDocument, bool>> filter)
        {
            return Documents.Find(filter);
        }

        public virtual ReplaceOneResult Replace(Expression<Func<TDocument, bool>> filter, TDocument document)
        {
            return Documents.ReplaceOne(filter, document, new UpdateOptions {IsUpsert = true});
        }
    }
}