namespace ICI.SSL.Core
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int subscriptionId, Certificate certificate);
        Task<Order> GetOrderAsync(int subscriptionId, Certificate certificate);
        Task ValidateOrderAsync(int subscriptionId, Certificate certificate);
        Task FinalizeOrderAsync(int subscriptionId, Certificate certificate);
    }
}
