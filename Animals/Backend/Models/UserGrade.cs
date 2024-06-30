namespace Backend.Models
{
    public class UserGrade
    {
        public int Id { get; set; }
        public DateTime GradeDate { get; set; }
        public string Comment { get; set; }
        public int Grade { get; set; }
        public int GraderId { get; set; }
        public int GradedId { get; set; }

        public UserGrade() { }

        public UserGrade(int id, DateTime gradeDate, string comment, int grade, int graderId, int gradedId)
        {
            Id = id;
            GradeDate = gradeDate;
            Comment = comment;
            Grade = grade;
            GraderId = graderId;
            GradedId = gradedId;
        }
    }
}
