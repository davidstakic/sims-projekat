namespace Backend.Models.AnimalModels
{
    public class AnimalSpecie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AnimalSpecie() { }
        public AnimalSpecie(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
