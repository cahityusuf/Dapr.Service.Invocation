using Basket.Abstraction.Dtos;
using Basket.Abstraction.Services;
using Microservice.Abstraction.Application.Models;

namespace Basket.Application.Services
{
    public class BasketService : IBasketService
    {
        public async Task<Result<BasketDto>> UpdateBasketAsync(BasketDto basket)
        {
            return new SuccessResult<BasketDto>(basket)
            {
                Messages = new List<string>
                {
                    "Ürün sepete kaydedildi"
                }
            };
        }
    }
}
