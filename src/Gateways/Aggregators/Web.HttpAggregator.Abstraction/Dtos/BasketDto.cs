namespace Web.HttpAggregator.Abstraction.Dtos;

public class BasketDto
{
    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
}
