using System;
using DataServices.MongoDB.Base.DataObjects;
using DataServices.MongoDB.Infrastructure;
using DataServices.MongoDB.Infrastructure.Helpers;

namespace Learning.DockerMongoDB.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var settingsReader = new SettingsReader("data-service-mongodb.json");

            var dataService = new BaseDatabaseDataService<Person>(
                new DatabaseObject {Name = settingsReader.ReadDatabaseName()},
                new DatabaseCollectionObject {Name = settingsReader.ReadCollectionName("name-collection-01")});


            dataService.Add(new Person
            {
                FirstName = "Jack",
                LastName = "Daniels"
            });

            /*var firstUser = dataService.Find().FirstOrDefault();
            Console.WriteLine(firstUser.FirstName);*/

            Console.WriteLine("All completed.");
            Console.ReadLine();
        }
    }
}