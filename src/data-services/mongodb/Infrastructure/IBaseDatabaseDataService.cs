using System;
using System.Linq.Expressions;
using DataServices.MongoDB.Base.DataObjects;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DataServices.MongoDB.Infrastructure
{
    public interface IBaseDatabaseDataService<TDocument>
    {
        IMongoCollection<TDocument> Documents { get; }
        IDatabaseCollectionObject Collection { get; }
        void Add(TDocument document);
        DeleteResult Remove(Expression<Func<TDocument, bool>> filter);
        IMongoQueryable<TDocument> Find();
        IFindFluent<TDocument, TDocument> Find(Expression<Func<TDocument, bool>> filter);
        ReplaceOneResult Replace(Expression<Func<TDocument, bool>> filter, TDocument document);
    }
}