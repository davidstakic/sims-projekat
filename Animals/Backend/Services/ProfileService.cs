using Backend.Models.UserModels;
using Backend.Repositories.Interface;
using Backend.Utils;

namespace Backend.Services
{
    public class ProfileService : Service<Profile>
    {
        public ProfileService() : base((IRepository<Profile>)Injector.GetRepositoryInstance("IProfileRepository"))
        {
        }

        public void ChangePassword(Profile profile, string newPassword)
        {
            profile.Password = newPassword;
            Update(profile);
        }
    }
}
