using ClassDi.Web.Data;
using ClassDi.Web.Pages;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests;

public class IndexTests
{
    readonly Mock<PersonRepository> _personRepoMock = new();
    readonly IndexModel _sut;

    public IndexTests() => _sut = new(Mock.Of<ILogger<IndexModel>>(), _personRepoMock.Object);

    [Fact]
    public async Task WhenGettingPage_ThenPeopleAreFilled()
    {
        _personRepoMock.Setup(m => m.GetPeopleAsync()).ReturnsAsync(new List<Person>() { new("a", "b"), new("c", "d"), new("e", "f") });

        await _sut.OnGet();

        Assert.Equal(3, _sut.Persons.Count);
    }
}