namespace Backend.Models.VetOfficeModels
{
    public class VetOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateOnly EstablishedDate { get; set; }
        public string AccountNumber { get; set; }
        public List<int> AssociationIds { get; set; }

        public VetOffice() { }
        public VetOffice(int id, string name, string address, DateOnly establishedDate, List<int> associationIds, string accountNumber)
        {
            Id = id;
            Name = name;
            Address = address;
            EstablishedDate = establishedDate;
            AssociationIds = associationIds;
            AccountNumber = accountNumber;
        }
    }
}
