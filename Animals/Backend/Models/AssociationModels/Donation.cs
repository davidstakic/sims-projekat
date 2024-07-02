namespace Backend.Models.AssociationModels
{
    public class Donation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int MemberId { get; set; }
        public int AnimalId { get; set; }
        public int AssociationId { get; set; }

        public Donation() { }
        public Donation(DateTime date, int amount, int memberId, int animalId, int associationId)
        {
            Date = date;
            Amount = amount;
            MemberId = memberId;
            AnimalId = animalId;
            AssociationId = associationId;
        }
        public Donation(int id, DateTime date, int amount, int memberId, int animalId, int associationId)
        {
            Id = id;
            Date = date;
            Amount = amount;
            MemberId = memberId;
            AnimalId = animalId;
            AssociationId = associationId;
        }
    }
}
