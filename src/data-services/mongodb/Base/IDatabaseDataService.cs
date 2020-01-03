using DataServices.MongoDB.Base.DataObjects;

namespace DataServices.MongoDB.Base
{
    public interface IDatabaseDataService
    {
        IDatabaseCollectionObject Collection { get; }
    }
}