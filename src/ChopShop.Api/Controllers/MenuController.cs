using Microsoft.AspNetCore.Mvc;

namespace ChopShop.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuController : ControllerBase
{
    private static readonly Dish[] Dishes =
    {
        new ("Pork Sausage", 6),
        new ("Grilled beef steak", 10),
        new ("Teriyaki chicken", 5)
    };

    [HttpGet]
    public IEnumerable<Dish> Get()
    {
        return Dishes;
    }
}