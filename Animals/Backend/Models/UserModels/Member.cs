using Backend.Models.Enums;

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
    }
}
