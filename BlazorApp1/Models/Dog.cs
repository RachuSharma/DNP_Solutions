namespace BlazorApp1.Models;

public class Dog
{
    public int DogId { get; set; }
    public string Name { get; set; }
    public string Sex { get; set; }
    public string Breed { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public DateTime RegisterTime { get; set; }


    public Dog(int dogId, string name, string sex, string breed, string imageUrl, string description, DateTime registerTime)
    {
        DogId = dogId;
        Name = name;
        Sex = sex;
        Breed = breed;
        ImageUrl = imageUrl;
        Description = description;
        RegisterTime = registerTime;}
}