using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Learning.DockerMongoDB.App
{
    public class Person
    {
        [BsonId] public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}