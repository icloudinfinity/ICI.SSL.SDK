namespace ICI.SSL.Core
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Certificate certificate);
        Task<Order> GetOrderAsync(Certificate certificate);
        Task ValidateOrderAsync(Certificate certificate);
        Task FinalizeOrderAsync(Certificate certificate);
    }
}
