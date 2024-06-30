using Backend.Utils;

namespace Backend.Models.UserModels
{
    public class Member : User
    {
        public bool IsBlacklisted { get; set; }
        public Status Status { get; set; }

        public Member() { }

        public Member(bool isBlacklisted, Status status) : base()
        {
            IsBlacklisted = isBlacklisted;
            Status = status;
        }
        public Member(int id, string name, string phoneNumber, string email, DateOnly birthDate, Gender gender, int profileId, int associationId, bool isBlacklisted, Status status) : base()
        {
            IsBlacklisted = isBlacklisted;
            Status = status;
        }
    }
}
