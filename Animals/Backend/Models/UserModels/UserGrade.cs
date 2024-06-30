namespace Backend.Models.UserModels
{
    public class UserGrade
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int Grade { get; set; }
        public int GraderId { get; set; }
        public int GradedId { get; set; }

        public UserGrade() { }
        public UserGrade(int id, DateTime date, string comment, int grade, int graderId, int gradedId)
        {
            Id = id;
            Date = date;
            Comment = comment;
            Grade = grade;
            GraderId = graderId;
            GradedId = gradedId;
        }
    }
}
