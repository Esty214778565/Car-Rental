using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.IService
{
    public interface ICollectionPointService
    {
        List<CollectionPointEntity> GetCollectionPointList();
        CollectionPointEntity GetCollectionPointById(int id);
        bool Add(CollectionPointEntity collectionPoint);
        bool Update(CollectionPointEntity collectionPoint);
        bool Delete(int id);
    }
}
