using Backend.Utils;

namespace Backend.Models.UserModels
{
    public class Volunteer : User
    {
        public bool IsAdmin { get; set; }
        public Volunteer() : base() { }
        public Volunteer(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }

        public Volunteer(int id, string name, string phoneNumber, string email, DateOnly birthDate, Gender gender, int profileId, bool idAdmin) : base()
        {
            IsAdmin = idAdmin;
        }
    }
}
