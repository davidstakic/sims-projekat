using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class UserGradeService : Service<UserGrade>
    {
        private readonly IUserGradeRepository _userGradeRepository;
        public UserGradeService() : base((IUserGradeRepository)Injector.GetRepositoryInstance("IUserGradeRepository"))
        {
            _userGradeRepository = (IUserGradeRepository)Injector.GetRepositoryInstance("IUserGradeRepository");
        }
    }
}
