using Basket.Abstraction.Dtos;
using Microservice.Abstraction.Application.Models;

namespace Basket.Abstraction.Services
{
    public interface IBasketService
    {
        Task<Result<BasketDto>> UpdateBasketAsync(BasketDto basket);
    }
}
