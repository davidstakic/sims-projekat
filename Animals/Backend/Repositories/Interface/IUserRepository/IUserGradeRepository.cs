using Backend.Models.UserModels;
using Backend.Repositories.Interface;

namespace Backend.Repositories.Interface.IRepositoryUser
{
    public interface IUserGradeRepository : IRepository<UserGrade>
    {
        IEnumerable<UserGrade> GetUserGradeByGradedId(int gradedId);
        IEnumerable<UserGrade> GetUserGradeByGraderId(int graderId);
    }
}
