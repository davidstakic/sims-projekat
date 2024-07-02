using Backend.Models.UserModels;

namespace Backend.Repositories.Interfaces.UserInterfaces
{
    public interface IUserGradeRepository : IRepository<UserGrade>
    {
        IEnumerable<UserGrade> GetUserGradeByGradedId(int gradedId);
        IEnumerable<UserGrade> GetUserGradeByGraderId(int graderId);
    }
}
