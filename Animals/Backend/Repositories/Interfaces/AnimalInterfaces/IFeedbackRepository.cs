using Backend.Models.AnimalModels;

namespace Backend.Repositories.Interfaces.AnimalInterfaces
{
    public interface IFeedbackRepository : IRepository<AnimalFeedback>
    {
        IEnumerable<AnimalFeedback> GetAnimalFeedbackByMemberId(int memberId);
        IEnumerable<AnimalFeedback> GetAnimalFeedbackByAnimalId(int animalId);
    }
}
