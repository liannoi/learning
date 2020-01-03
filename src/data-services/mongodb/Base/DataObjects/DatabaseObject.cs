namespace DataServices.MongoDB.Base.DataObjects
{
    public struct DatabaseObject : IDatabaseObject
    {
        public string DBMSAddress { get; set; }
        public string Name { get; set; }
    }
}