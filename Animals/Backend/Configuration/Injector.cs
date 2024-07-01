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
            Instances.Add("IAdoptionRepository", new AdoptionRepository("../../../../Backend/Data/Adoptions.json"));
            Instances.Add("IAnimalRepository", new AnimalRepository("../../../../Backend/Data/Animals.json"));
            Instances.Add("IFeedbackRepository", new FeedbackRepository("../../../../Backend/Data/Feedbacks.json"));
            Instances.Add("ISpecieRepository", new SpecieRepository("../../../../Backend/Data/Species.json"));
            Instances.Add("IAssociationRepository", new AssociationRepository("../../../../Backend/Data/Associations.json"));
            Instances.Add("IDonationRepository", new DonationRepository("../../../../Backend/Data/Donations.json"));
            Instances.Add("ICommentRepository", new CommentRepository("../../../../Backend/Data/Comments.json"));
            Instances.Add("ILikeRepository", new LikeRepository("../../../../Backend/Data/Likes.json"));
            Instances.Add("IPostRepository", new PostRepository("../../../../Backend/Data/Posts.json"));
            Instances.Add("IMemberRepository", new MemberRepository("../../../../Backend/Data/Members.json"));
            Instances.Add("IMessageRepository", new MessageRepository("../../../../Backend/Data/Messages.json"));
            Instances.Add("IProfileRepository", new ProfileRepository("../../../../Backend/Data/Profiles.json"));
            Instances.Add("IUserGradeRepository", new UserGradeRepository("../../../../Backend/Data/UserGrades.json"));
            Instances.Add("IVolunteerRepository", new VolunteerRepository("../../../../Backend/Data/Volunteers.json"));
            Instances.Add("ITreatmentRepository", new TreatmentRepository("../../../../Backend/Data/Treatments.json"));
            Instances.Add("IVetOfficeRepository", new VetOfficeRepository("../../../../Backend/Data/VetOffices.json"));
            Instances.Add("IVoteRepository", new VoteRepository("../../../../Backend/Data/Votes.json"));
            Instances.Add("IVotingRepository", new VotingRepository("../../../../Backend/Data/Votings.json"));
        }
    }
}
