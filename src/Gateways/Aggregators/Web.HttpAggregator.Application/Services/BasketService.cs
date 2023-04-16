using Dapr.Client;
using Microservice.Abstraction.Application.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Web.HttpAggregator.Abstraction.Dtos;
using Web.HttpAggregator.Abstraction.Services;

namespace Web.HttpAggregator.Application.Services
{
    public class BasketService: IBasketService
    {

        public async Task<Result<BasketDto>> CreateAsync(BasketDto basket)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/basket")
            {
                Content = JsonContent.Create(basket)
            };

            var httpClient = DaprClient.CreateInvokeHttpClient("basket-api");

            var response = await httpClient.SendAsync(request);


            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SuccessResult<BasketDto>>(content);
            }

            return new NoContentResult<BasketDto>();
        }

    }
}
