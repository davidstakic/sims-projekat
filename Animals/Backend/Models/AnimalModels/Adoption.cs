using Backend.Models.Enums;

namespace Backend.Models.AnimalModels
{
    public class Adoption
    {
        public int Id { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public Status Status { get; set; }
        public int MemberId { get; set; }
        public int AnimalId { get; set; }

        public Adoption() { }
        public Adoption(int id, DateOnly start, DateOnly end, Status status, int memberId, int animalId)
        {
            Id = id;
            Start = start;
            End = end;
            Status = status;
            MemberId = memberId;
            AnimalId = animalId;
        }
    }
}
