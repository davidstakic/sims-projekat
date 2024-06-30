namespace Backend.Models.AnimalModels
{
    public class AnimalFeedback
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Grade { get; set; }
        public string Feedback { get; set; }
        public int MemberId { get; set; }
        public int AnimalId { get; set; }

        public AnimalFeedback() { }
        public AnimalFeedback(int id, DateTime creationDate, int grade, string feedback, int memberId, int animalId)
        {
            Id = id;
            CreationDate = creationDate;
            Grade = grade;
            Feedback = feedback;
            MemberId = memberId;
            AnimalId = animalId;
        }
    }
}
