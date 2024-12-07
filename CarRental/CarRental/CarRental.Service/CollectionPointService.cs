using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using CarRental.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service
{
    public class CollectionPointService : ICollectionPointService
    {

     
        readonly IRepository<CollectionPointEntity> _CollectionPointRepository;

        public CollectionPointService(IRepository<CollectionPointEntity> collectionPointRepository)
        {
            _CollectionPointRepository = collectionPointRepository;
        }

        public List<CollectionPointEntity> GetCollectionPointList()
        {
            return _CollectionPointRepository.GetAllData();
        }

        public CollectionPointEntity GetCollectionPointById(int id)
        {
            return _CollectionPointRepository.GetById(id);
        }

        public bool Add(CollectionPointEntity CollectionPoint)
        {

            if (_CollectionPointRepository.GetIndexById(CollectionPoint.Id) >-1)
                return false;
            return _CollectionPointRepository.Add(CollectionPoint);
        }

        public bool Update(CollectionPointEntity CollectionPoint)
        {
            if (_CollectionPointRepository.GetIndexById(CollectionPoint.Id)<0)
                return false;
            return _CollectionPointRepository.Update(CollectionPoint);
        }

        public bool Delete(int id)
        {

            if (_CollectionPointRepository.GetIndexById(id) < 0)
                return false;
            return _CollectionPointRepository.Delete(id);
        }

    }

}
