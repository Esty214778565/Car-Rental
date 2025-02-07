using CarRental.Core.DTOs;
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
        List<CollectionPointDto> GetCollectionPointList();
        CollectionPointDto GetCollectionPointById(int id);
        bool Add(CollectionPointDto collectionPoint);
        bool Update(CollectionPointDto collectionPoint);
        bool Delete(int id);
    }
}
