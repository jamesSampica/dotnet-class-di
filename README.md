# Introduction

A simple example of implementing dependency injection without using single-use interfaces.

# Motivation

Single use interfaces are very common in modern .NET development because they are mock friendly but less know of a way to create mock-friendly classes without the use of a single-use interface.

The advantage of this approach is a bit less code and a more intentional design. We avoid creating interfaces where we don't intend polymorphic actions to occur on them.

An example of the common approach is as follows:

    public interface IPersonRepository
    {
        Task<List<Person>> GetPeopleAsync();
    }

    public class PersonRepository : IPersonRepository
    {
        public Task<List<Person>> GetPeopleAsync()
        {
            ...
        }
    }

    ...

    readonly IPersonRepository _personRepository;

    public IndexModel(IPersonRepository personRepository) => _personRepository = personRepository;

Another approach is marking our class methods `virtual` which allows overriding manually or via a mocking library. 

Then we simply register and inject the class directly instead of relying on an interface as shown below.

    public class PersonRepository
    {
        public virtual Task<List<Person>> GetPeopleAsync()
        {
            ...
        }
    }

    ...

    readonly PersonRepository _personRepository;

    public IndexModel(PersonRepository personRepository) => _personRepository = personRepository;

Note that this isn't a new or novel approach, just one I don't see a lot in modern .NET codebases :)