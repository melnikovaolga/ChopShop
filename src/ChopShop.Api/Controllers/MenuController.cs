using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChopShop.Api.Controllers;

[ApiController]
[Authorize]
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
    public IActionResult Get()
    {
        return Content(string.Join(",", Dishes.Select(dish => dish.Name)));
    }
}