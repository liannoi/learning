// Copyright 2020 Maksym Liannoi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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