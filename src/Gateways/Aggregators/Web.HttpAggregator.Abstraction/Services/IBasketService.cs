using Microservice.Abstraction.Application.Models;
using Web.HttpAggregator.Abstraction.Dtos;

namespace Web.HttpAggregator.Abstraction.Services
{
    public interface IBasketService
    {
        Task<Result<BasketDto>> CreateAsync(BasketDto basket);
    }
}
