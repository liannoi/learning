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
                new DatabaseObject
                {
                    Name = settingsReader.ReadDatabaseName(),
                    DBMSAddress = settingsReader.ReadDBMSAddress()
                },
                new DatabaseCollectionObject
                {
                    Name = settingsReader.ReadCollectionName("name-collection-01")
                });


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