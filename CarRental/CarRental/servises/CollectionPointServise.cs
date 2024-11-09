using CarRental.Entity;

namespace CarRental.servises
{
    public class CollectionPointServise
    {
      
      
        public List<CollectionPoint> getCollectionPoints()
        {
            if (DataContextManager.DataContext.CollectionPoints == null)
                DataContextManager.DataContext.CollectionPoints = new List<CollectionPoint>();
            return DataContextManager.DataContext.CollectionPoints;
        }

        public CollectionPoint GetCollectionPointById(int id)
        {
            return DataContextManager.DataContext.CollectionPoints.Find(CollectionPoint => CollectionPoint.Id == id);
        }

        public bool Update(int id, CollectionPoint CollectionPoint)
        {
            CollectionPoint ca = DataContextManager.DataContext.CollectionPoints.Find(c => c.Id == id);
            if (ca == null)
                return false;
            DataContextManager.DataContext.CollectionPoints.Remove(ca);
            DataContextManager.DataContext.CollectionPoints.Add(CollectionPoint);
            return true;
        }
        public bool Add(CollectionPoint CollectionPoint)
        {
            if(DataContextManager.DataContext.CollectionPoints == null)
                DataContextManager.DataContext.CollectionPoints = new List<CollectionPoint>();
            DataContextManager.DataContext.CollectionPoints.Add(CollectionPoint);
            return true;
        }
        public bool DeleteCollectionPoint(int id)
        {
            CollectionPoint CollectionPoint = DataContextManager.DataContext.CollectionPoints.Find(i => i.Id == id);
            if (CollectionPoint == null)
                return false;
            DataContextManager.DataContext.CollectionPoints.Remove(CollectionPoint);
            return true;
        }


    }
}
