using Backend.Models.AnimalModels;
using Backend.Repositories.Interface.IAnimalRepository;

namespace Backend.Repositories.AnimalRepository
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

        IEnumerable<AnimalFeedback> IFeedbackRepository.GetAnimalFeedbackByMemberId(int memberId)
        {
            return GetAll().Where(m => m.MemberId == memberId);
        }
    }
}
