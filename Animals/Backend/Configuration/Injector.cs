using Backend.Repositories.AnimalRepositories;
using Backend.Repositories.AssociationRepositories;
using Backend.Repositories.PostRepositories;
using Backend.Repositories.UserRepositories;
using Backend.Repositories.VetOfficeRepositories;
using Backend.Repositories.VoteRepositories;

namespace Backend.Configuration
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
            Instances.Add("ISpecieRepository", new SpecieRepository("../../../Data/Species.json"));
            Instances.Add("IAssociationRepository", new AssociationRepository("../../../Data/Associations.json"));
            Instances.Add("IDonationRepository", new DonationRepository("../../../Data/Donations.json"));
            Instances.Add("ICommentRepository", new CommentRepository("../../../Data/Comments.json"));
            Instances.Add("ILikeRepository", new LikeRepository("../../../Data/Likes.json"));
            Instances.Add("IPostRepository", new PostRepository("../../../Data/Posts.json"));
            Instances.Add("IMemberRepository", new MemberRepository("../../../Data/Members.json"));
            Instances.Add("IMessageRepository", new MessageRepository("../../../Data/Messages.json"));
            Instances.Add("IProfileRepository", new ProfileRepository("../../../Data/Profiles.json"));
            Instances.Add("IUserGradeRepository", new UserGradeRepository("../../../Data/UserGrades.json"));
            Instances.Add("IUserRepository", new UserRepository("../../../Data/Users.json"));
            Instances.Add("IVolunteerRepository", new VolunteerRepository("../../../Data/Volunteers.json"));
            Instances.Add("ITreatmentRepository", new TreatmentRepository("../../../Data/Treatments.json"));
            Instances.Add("IVetOfficeRepository", new VetOfficeRepository("../../../Data/VetOffices.json"));
            Instances.Add("IVoteRepository", new VoteRepository("../../../Data/Votes.json"));
            Instances.Add("IVotingRepository", new VotingRepository("../../../Data/Votings.json"));
        }
    }
}
