namespace Backend.Models.VetOfficeModels
{
    public class Treatment
    {
        public int Id { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public int AnimalId { get; set; }
        public int VetOfficeId { get; set; }

        public Treatment() { }
        public Treatment(int id, DateOnly start, DateOnly end, int animalId, int vetOfficeId)
        {
            Id = id;
            Start = start;
            End = end;
            AnimalId = animalId;
            VetOfficeId = vetOfficeId;
        }
    }
}
