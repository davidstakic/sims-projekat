namespace Backend.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Profile() { }
        public Profile(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }
    }
}
