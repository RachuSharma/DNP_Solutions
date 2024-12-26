using System.Text.Json;
using BlazorApp1.Models;

namespace BlazorApp1.Service;

public class KennelService : IKennelService
{
    private readonly List<Dog> _dogs;

    public KennelService()
    {
        _dogs = new List<Dog>
        {
            new Dog(1, "Buddy", "Male", "Labrador Retriever",
                "https://http.dog/100.jpg",
                "aaaaaaaaaa", DateTime.Now),

            new Dog(2, "Tomi", "Female", "Västgötaspits",
                "https://httpcats.com/226.jpg",
                "I dont know", DateTime.Now),
            new Dog(3, "Jack", "Male", "Poodle",
                "https://http.dog/102.jpg",
                "I dont know", DateTime.Now),
            new Dog(4, "Luna", "Female", "Golden Retriever",
                "https://http.dog/103.jpg",
                "I dont know", DateTime.Now),
            new Dog(5, "Rocky", "Male", "German Shepherd",
                "https://http.dog/200.jpg",
                "I dont know", DateTime.Now)
        };
    }

    public Task RegisterDog(Dog dog)
    {
        dog.RegisterTime = DateTime.Now;

        dog.DogId = _dogs.Count + 1;

        Console.WriteLine(JsonSerializer.Serialize(dog));
        _dogs!.Add(dog);
        return Task.CompletedTask;
    }

    public Task<List<Dog>> GetDogs()
    {
        return Task.FromResult(_dogs);

    }

    public Task<Dog> GetDog(int id)
    {
        return Task.FromResult(_dogs.FirstOrDefault(d => d.DogId == id));
    }
}