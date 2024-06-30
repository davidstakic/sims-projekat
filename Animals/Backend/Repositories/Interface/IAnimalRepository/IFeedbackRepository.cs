using Backend.Models.AnimalModels;

namespace Backend.Repositories.Interface.IAnimalRepository
{
    public interface IFeedbackRepository
    {
        IEnumerable<AnimalFeedback> GetAnimalFeedbackByMemberId(int memberId);
        IEnumerable<AnimalFeedback> GetAnimalFeedbackByAnimalId(int animalId);
    }
}
