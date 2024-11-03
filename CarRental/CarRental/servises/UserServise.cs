namespace CarRental.servises
{
    public class UserServise
    {
        public List<User> Users { get; set; }
        public UserServise()
        {
            Users = new List<User>();
            
        }
        public List<User> getUsers()
        {
            return Users;
        }

        public User GetUserById(int id)
        {
            return Users.Find(user => user.Id == id);
        }

        public bool PutUser(int id, User user)
        {
            User ua = Users.Find(u => u.Id == id);
            if (ua == null)
                return false;
            Users.Remove(ua);
            Users.Add(user);
            return true;
        }
        public bool PostUser(User user)
        {
            Users.Add(user);
            return true;
        }
        public bool DeleteUser(int id)
        {
            User user = Users.Find(i => i.Id == id);
            if (user == null)
                return false;
            Users.Remove(user);
            return true;
        }
    }
}
