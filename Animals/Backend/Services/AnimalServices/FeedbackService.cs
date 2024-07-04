using Backend.Configuration;
using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Services.AnimalServices
{
    public class FeedbackService : Service<AnimalFeedback>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService() : base((IFeedbackRepository)Injector.GetRepositoryInstance("IFeedbackRepository"))
        {
            _feedbackRepository = (IFeedbackRepository)Injector.GetRepositoryInstance("IFeedbackRepository");
        }

        public List<AnimalFeedback> GetAnimalFeedbackByAnimalId(int animalId)
        {
            return _feedbackRepository.GetAnimalFeedbackByAnimalId(animalId).ToList();
        }
    }
}
