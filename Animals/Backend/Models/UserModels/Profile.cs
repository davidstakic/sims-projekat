namespace Backend.Models.UserModels
{
    public class Profile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }

        public Profile() { }
        public Profile(int id, string username, string password, DateTime creationDate)
        {
            Id = id;
            Username = username;
            Password = password;
            CreationDate = creationDate;
        }
    }
}
