namespace CarRental.api.Models
{
    public class UserPostModel
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public string Name { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Zip_code { get; set; }
        public string Phone { get; set; }
    }
}
