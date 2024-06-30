namespace Backend.Models
{
    public class Association
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateOnly EstablishedDate { get; set; }
        public string AccountNumber { get; set; }
        public List<int> VetOfficeIds { get; set; }

        public Association() { }
        public Association (int id, string name, string address, DateOnly establishedDate, string accountNumber, List<int> vetOfficeIds)
        {
            Id = id;
            Name = name;
            Address = address;
            EstablishedDate = establishedDate;
            AccountNumber = accountNumber;
            VetOfficeIds = vetOfficeIds;
        }
    }
}
