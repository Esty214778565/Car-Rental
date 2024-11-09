namespace CarRental
{
    public class Validation<T>
    {

        public bool Check(T value)
        {

            if (value == null)
                return false;
            return true;
        }






    }
}
