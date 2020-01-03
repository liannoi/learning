namespace DataServices.MongoDB.Base.DataObjects
{
    public interface IDatabaseObject
    {
        string Name { get; set; }
        string DBMSAddress { get; set; }
    }
}