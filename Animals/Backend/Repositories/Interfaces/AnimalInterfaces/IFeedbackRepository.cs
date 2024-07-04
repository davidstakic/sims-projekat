using Backend.Models.AnimalModels;

namespace Backend.Repositories.Interfaces.AnimalInterfaces
{
    public interface IFeedbackRepository : IRepository<AnimalFeedback>
    {
        IEnumerable<AnimalFeedback> GetAnimalFeedbackByAnimalId(int animalId);
    }
}
