using Backend.Models.UserModels;
using Backend.Repositories.Interface;
using Backend.Utils;

namespace Backend.Services
{
    public class UserGradeService : Service<UserGrade>
    {
        public UserGradeService() : base((IRepository<UserGrade>)Injector.GetRepositoryInstance("IUserGradeRepository"))
        {
        }

        public void GradeUser(UserGrade grade)
        {
            new UserGradeService().Create(new UserGrade(grade.Date, grade.Comment, grade.Grade, grade.GraderId, grade.GradedId));
        }
    }
}
