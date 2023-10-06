using ClassDi.Web.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDi.Web.Pages;

public class IndexModel : PageModel
{
    readonly ILogger<IndexModel> _logger;
    readonly PersonRepository _personRepository;

    public List<Person> Persons { get; set; } = new();

    public IndexModel(ILogger<IndexModel> logger, PersonRepository personRepository)
    {
        _logger = logger;
        _personRepository = personRepository;
    }

    public async Task OnGet()
    {
        Persons = await _personRepository.GetPeopleAsync();
    }
}