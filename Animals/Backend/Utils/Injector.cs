using Backend.Models.UserModels;
using Backend.Repositories;
using Backend.Repositories.AnimalRepository;
using Backend.Repositories.AssociationRepository;
using Backend.Repositories.PostRepository;
using Backend.Repositories.UserRepository;
using Backend.Repositories.UserRepository.UserRepository;
using Backend.Repositories.VetOfficeRepository;
using Backend.Repositories.VoteRepository.VoteRepository;

namespace Backend.Utils
{
    public static class Injector
    {
        private static readonly Dictionary<string, object> Instances = new();

        public static object GetRepositoryInstance(string repositoryName)
        {
            return Instances[repositoryName];
        }

        public static object GetInstance(string instanceName)
        {
            return Instances[instanceName];
        }

        static Injector()
        {
            Instances.Add("IAdoptionRepository", new AdoptionRepository("../../../Data/Adoptions.json"));
            Instances.Add("IAnimalRepository", new AnimalRepository("../../../Data/Animals.json"));
            Instances.Add("IFeedbackRepository", new FeedbackRepository("../../../Data/Feedbacks.json"));
            Instances.Add("IAssociationRepository", new AssociationRepository("../../../Data/Associations.json"));
            Instances.Add("IDonationRepository", new DonationRepository("../../../Data/Donations.json"));
            Instances.Add("ICommentRepository", new CommentRepository("../../../Data/Comments.json"));
            Instances.Add("ILikeRepository", new LikeRepository("../../../Data/Likes.json"));
            Instances.Add("IPostRepository", new PostRepository("../../../Data/Posts.json"));
            Instances.Add("IMessageRepository", new MessageRepository("../../../Data/Messages.json"));
            Instances.Add("IUserGradeRepository", new UserGradeRepository("../../../Data/UserGrades.json"));
            Instances.Add("IUserRepository", new UserRepository("../../../Data/Users.json"));
            Instances.Add("ITreatmentRepository", new TreatmentRepository("../../../Data/Treatments.json"));
            Instances.Add("IVetOfficeRepository", new VetOfficeRepository("../../../Data/VetOffices.json"));
            Instances.Add("IVoteRepository", new VoteRepository("../../../Data/Votes.json"));
            Instances.Add("IVotingRepository", new VotingRepository("../../../Data/Votings.json"));
            Instances.Add("IProfileRepository", new Repository<Profile>("../../../Data/Profiles.json"));
        }
    }
}
