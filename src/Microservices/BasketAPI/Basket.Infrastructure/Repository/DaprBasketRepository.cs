using Basket.Domain.Entities;
using Basket.Domain.Repository;
using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace Basket.Infrastructure.Repository
{
    public class DaprBasketRepository : IBasketRepository
    {
        private const string StateStoreName = "eshopondapr-statestore";

        private readonly DaprClient _daprClient;
        private readonly ILogger _logger;

        public DaprBasketRepository(DaprClient daprClient, ILogger<DaprBasketRepository> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        public Task DeleteBasketAsync(string id) =>
            _daprClient.DeleteStateAsync(StateStoreName, id);

        public Task<CustomerBasket> GetBasketAsync(string customerId) =>
            _daprClient.GetStateAsync<CustomerBasket>(StateStoreName, customerId);

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var state = await _daprClient.GetStateEntryAsync<CustomerBasket>(StateStoreName, basket.BuyerId);
            state.Value = basket;

            await state.SaveAsync();

            _logger.LogInformation("Basket item persisted successfully.");

            return await GetBasketAsync(basket.BuyerId);
        }
    }
}
