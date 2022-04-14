using System.Diagnostics;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using FakeThrower.Models;
using System.Net;

namespace FakeThrower.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var fakeUser = new Faker<User>("en")
            .RuleFor(x => x.Id, x => x.IndexFaker)
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.PhoneNumber, x => x.Phone.PhoneNumberFormat())
            .FinishWith((f, u) =>
            {
                Console.WriteLine("Fake user created!");
            });

        var user = fakeUser.Generate(20);

        return await Task.Run(() => View(user));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}