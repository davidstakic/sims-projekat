using Backend.Models.Enums;

namespace Backend.Models.UserModels
{
    public class Volunteer : User
    {
        public bool IsAdmin { get; set; }

        public Volunteer() { }
        public Volunteer(int id, string firstName, string lastName, string phoneNumber, string email, DateOnly birthDate, Gender gender, int profileId, int associationId, bool isAdmin) : base(id, firstName, lastName, phoneNumber, email, birthDate, gender, profileId, associationId)
        {
            IsAdmin = isAdmin;
        }
    }
}
