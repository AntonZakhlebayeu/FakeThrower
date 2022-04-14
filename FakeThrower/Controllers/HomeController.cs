using System.Diagnostics;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using FakeThrower.Models;

namespace FakeThrower.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/Home/Index/{lang}")]
    public async Task<ActionResult> Index(string lang = "en")
    {
        var number = 0;

        var rnd = new Random();
        var seed = rnd.Next(86400);
        Randomizer.Seed = new Random(rnd.Next(seed));
        var fakeUser = new Faker<User>(lang)
            .RuleFor(x => x.Seed, x => seed)
            .RuleFor(x => x.Number, x => ++number)
            .RuleFor(x => x.Id, x => x.Random.Int(0, 1000))
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.Adress, x=> x.Address.Country() + " " + x.Address.City() + " " + x.Address.StreetName())
            .RuleFor(x => x.PhoneNumber, x => x.Phone.PhoneNumberFormat());

        var user = fakeUser.Generate(20);

        return await Task.Run(() => View(user));
    }

    [HttpPost]
    [Route("/Home/Index/{lang}")]
    public async Task<ActionResult> Index(int seed, string lang = "en")
    {
        var number = 0;

        var rnd = new Random();

        if (seed == 0)
            seed = rnd.Next(86400);

        Randomizer.Seed = new Random(rnd.Next(seed));
        var fakeUser = new Faker<User>(lang)
            .RuleFor(x => x.Seed, x => seed)
            .RuleFor(x => x.Number, x => ++number)
            .RuleFor(x => x.Id, x => x.Random.Int(0, 1000))
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.Adress, x=> x.Address.Country() + " " + x.Address.City() + " " + x.Address.StreetName())
            .RuleFor(x => x.PhoneNumber, x => x.Phone.PhoneNumberFormat());

        var user = fakeUser.Generate(20);

        return await Task.Run(() => View(user));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}