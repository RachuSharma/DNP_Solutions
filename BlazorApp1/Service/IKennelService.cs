using BlazorApp1.Models;

namespace BlazorApp1.Service;

public interface IKennelService
{
    public Task RegisterDog(Dog dog);
    public Task<List<Dog>> GetDogs(); 
}