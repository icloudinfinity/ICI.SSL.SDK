namespace ICI.SSL.Core
{
    public interface INotificationService
    {
        Task<Notification> Create(int subscriptionId, Notification notification);
        Task<Notification> GetByIdAsync(int subscriptionId, int id);
        Task<List<Notification>> GetAll(int subscriptionId);
        Task DeleteAsync(int subscriptionId, int id);
    }
}
