using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.HttpAggregator.Abstraction.Dtos;
using Web.HttpAggregator.Abstraction.Services;

namespace Web.HttpAggregator.Api.Controllers;

[Route("api/v1/[controller]")]
[AllowAnonymous]
[ApiController]
public class BasketController : ControllerBase
{

    private readonly IBasketService _basket;
    public BasketController(IBasketService basket)
    {
        _basket = basket;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BasketDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateAllBasketAsync(
        [FromBody] BasketDto basket)
    {
        return Ok(await _basket.CreateAsync(basket));
    }
}
