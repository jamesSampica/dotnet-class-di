namespace ClassDi.Web.Data;

public class PersonRepository
{
    public virtual Task<List<Person>> GetPeopleAsync()
    {
        return Task.FromResult(new List<Person>() { new("John", "Smith"), new("John", "Doe") });
    }
}

public record Person(string FirstName, string Surname);