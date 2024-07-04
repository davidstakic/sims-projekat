using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Repositories.AnimalRepositories
{
    public class FeedbackRepository : Repository<AnimalFeedback>, IFeedbackRepository
    {
        public FeedbackRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<AnimalFeedback> IFeedbackRepository.GetAnimalFeedbackByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId);
        }
    }
}
