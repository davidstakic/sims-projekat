using Backend.Models.UserModels;
using Backend.Repositories.Interface.IRepositoryUser;

namespace Backend.Repositories.UserRepository.UserRepository
{
    public class UserGradeRepositoryRepository : Repository<UserGrade>, IUserGradeRepository
    {
        public UserGradeRepositoryRepository(string filePath) : base(filePath)
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
