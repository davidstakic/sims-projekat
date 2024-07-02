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
    }
}
