using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Repository
{
    public class CollectionPointRepository : IRepository<CollectionPointEntity>
    {
        readonly DataContext _dataContext;

        public CollectionPointRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Add(CollectionPointEntity collectionPoint)
        {
            try
            {
                _dataContext.CollectionPoints.Add(collectionPoint);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                CollectionPointEntity c_p = _dataContext.CollectionPoints.ToList().Find(c => c.Id == id);
                _dataContext.CollectionPoints.Remove(c_p);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public List<CollectionPointEntity> GetAllDataAsync()
        {
            return _dataContext.CollectionPoints.ToList();
        }

        public CollectionPointEntity GetById(int id)
        {
            return _dataContext.CollectionPoints.ToList().Find(c => c.Id == id);
        }

        public bool Update(CollectionPointEntity collectionPoint)
        {
           int i = _dataContext.CollectionPoints.ToList().FindIndex(c => c.Id == collectionPoint.Id);
            if (i<0)
                return false;
            if(collectionPoint.Adress!="")
                _dataContext.CollectionPoints.ToList()[i].Adress = collectionPoint.Adress;
           if(collectionPoint.City!="")
                _dataContext.CollectionPoints.ToList()[i].City = collectionPoint.City;
            if(collectionPoint.Accessible_to_disabled !=null)
                _dataContext.CollectionPoints.ToList()[i].Accessible_to_disabled = collectionPoint.Accessible_to_disabled;
            if(collectionPoint.Max_num_of_cars>0)
                _dataContext.CollectionPoints.ToList()[i].Max_num_of_cars=collectionPoint.Max_num_of_cars;
            if(collectionPoint.NumCollectionPoint>0)
                _dataContext.CollectionPoints.ToList()[i].NumCollectionPoint=collectionPoint.NumCollectionPoint;
            if (collectionPoint.Num_of_cars_occupancy > 0)
                _dataContext.CollectionPoints.ToList()[i].Num_of_cars_occupancy = collectionPoint.Num_of_cars_occupancy;
          

            try
            {
                _dataContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public int GetIndexById(int id)
        {
            return _dataContext.CollectionPoints.ToList().FindIndex(c => c.Id == id);
        }
    }
}
