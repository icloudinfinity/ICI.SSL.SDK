using Microsoft.Extensions.Options;

namespace ICI.SSL.Core
{
    public class NotificationService : ApiRequestBase, INotificationService
    {
        public NotificationService(IOptions<ApiOptions> options) : base(options)
        {
        }

        public async Task<Notification> Create(int subscriptionId, Notification notification)
        {
            string uri = $"v1/notification/subscription/{subscriptionId}/create";

            Notification _notification = await PutAsync<Notification, Notification>(uri, notification);

            return _notification;
        }

        public async Task<Notification> GetByIdAsync(int subscriptionId, int id)
        {
            string uri = $"v1/notification/subscription/{subscriptionId}/id/{id}/get";

            Notification notification = await GetAsync<Notification>(uri);

            return notification;
        }

        public async Task<List<Notification>> GetAll(int subscriptionId)
        {
            string uri = $"v1/notification/subscription/{subscriptionId}/get/all";

            List<Notification> notifications = await GetListResultAsync<Notification>(uri);

            return notifications;
        }

        public async Task DeleteAsync(int subscriptionId, int id)
        {
            string uri = $"v1/notification/subscription/{subscriptionId}/id/{id}/delete";

            await DeleteAsync(uri);
        }
    }
}
