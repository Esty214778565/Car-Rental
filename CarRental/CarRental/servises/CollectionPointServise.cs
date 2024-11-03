namespace CarRental.servises
{
    public class CollectionPointServise
    {
        public List<CollectionPoint> CollectionPoints { get; set; }
        public CollectionPointServise()
        {
            CollectionPoints = new List<CollectionPoint>();
         
        }
        public List<CollectionPoint> getCollectionPoints()
        {
            return CollectionPoints;
        }

        public CollectionPoint GetCollectionPointById(int id)
        {
            return CollectionPoints.Find(CollectionPoint => CollectionPoint.Id == id);
        }

        public bool PutCollectionPoint(int id, CollectionPoint CollectionPoint)
        {
            CollectionPoint ca = CollectionPoints.Find(c => c.Id == id);
            if (ca == null)
                return false;
            CollectionPoints.Remove(ca);
            CollectionPoints.Add(CollectionPoint);
            return true;
        }
        public bool PostCollectionPoint(CollectionPoint CollectionPoint)
        {
            CollectionPoints.Add(CollectionPoint);
            return true;
        }
        public bool DeleteCollectionPoint(int id)
        {
            CollectionPoint CollectionPoint = CollectionPoints.Find(i => i.Id == id);
            if (CollectionPoint == null)
                return false;
            CollectionPoints.Remove(CollectionPoint);
            return true;
        }


    }
}
