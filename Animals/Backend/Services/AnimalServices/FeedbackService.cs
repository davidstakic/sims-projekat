using Backend.Configuration;
using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Services.AnimalServices
{
    public class FeedbackService : Service<AnimalFeedback>
    {
        public FeedbackService() : base((IFeedbackRepository)Injector.GetRepositoryInstance("IFeedbackRepository"))
        {
        }

        public List<AnimalFeedback> GetAnimalFeedbackByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId).ToList();
        }

        public List<AnimalFeedback> GetAnimalFeedbackByMemberId(int memberId)
        {
            return GetAll().Where(m => m.MemberId == memberId).ToList();
        }
    }
}
