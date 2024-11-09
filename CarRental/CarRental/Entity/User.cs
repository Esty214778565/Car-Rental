namespace CarRental.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Zip_code { get; set; }
        public string Phone { get; set; }

        public User(int id, string tz, string name, string adress, string email, string password, int zip_code, string phone)
        {
            Id = id;
            Tz = tz;
            Name = name;
            Adress = adress;
            Email = email;
            Password = password;
            Zip_code = zip_code;
            Phone = phone;
        }
    }
}
