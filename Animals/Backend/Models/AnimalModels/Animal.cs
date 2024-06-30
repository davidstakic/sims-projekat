namespace Backend.Models.AnimalModels
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public DateOnly BirthDate { get; set; }
        public string HealthCondition { get; set; }
        public string Location { get; set; }
        public int AnimalSpecieId { get; set; }

        public Animal() { }
        public Animal(int id, string name, string breed, string color, DateOnly birthDate, string healthCondition, string location, int animalSpecieId)
        {
            Id = id;
            Name = name;
            Breed = breed;
            Color = color;
            BirthDate = birthDate;
            HealthCondition = healthCondition;
            Location = location;
            AnimalSpecieId = animalSpecieId;
        }
    }
}
