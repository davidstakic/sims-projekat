namespace Backend.Models.UserModels
{
    public class Volunteer : User
    {
        public bool IsAdmin { get; set; }

        public Volunteer() { }
        public Volunteer(bool isAdmin) : base()
        {
            IsAdmin = isAdmin;
        }
    }
}
