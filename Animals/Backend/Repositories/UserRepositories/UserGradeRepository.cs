using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Repositories.UserRepositories
{
    public class UserGradeRepository : Repository<UserGrade>, IUserGradeRepository
    {
        public UserGradeRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<UserGrade> IUserGradeRepository.GetUserGradeByGradedId(int gradedId)
        {
            return GetAll().Where(m => m.GradedId == gradedId);
        }

        IEnumerable<UserGrade> IUserGradeRepository.GetUserGradeByGraderId(int graderId)
        {
            return GetAll().Where(m => m.GraderId == graderId);
        }
    }
}
