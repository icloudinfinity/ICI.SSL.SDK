namespace ICI.SSL.Core.Test.Notification
{
    [TestClass]
    public class NotificationServiceTest
    {
        private readonly INotificationService _notificationService;
        private const int _subscriptionId = 12;

        public NotificationServiceTest()
        {
            _notificationService = (INotificationService)DependencyResolver.ServiceProvider()
                .GetService(typeof(INotificationService));
        }

        [TestMethod]
        public async Task CreateNotificationTest()
        {
            Core.Notification notification = new Core.Notification
            {
                date = DateTime.Now,
                message = "Test message",
                subscriptionId = _subscriptionId,
                type = NotificationConstants.Information
            };

            try
            {
                Core.Notification newNotification = await _notificationService.Create(_subscriptionId, notification);
                Assert.AreEqual(notification.message, notification?.message);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetNotificationByIdTest()
        {
            try
            {
                Core.Notification notification = await _notificationService.GetByIdAsync(_subscriptionId, 33);
                Assert.AreEqual(33, notification?.Id);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetAllNotificationsTest()
        {
            try
            {
                List<Core.Notification> notifications = await _notificationService.GetAll(_subscriptionId);
                Assert.AreNotEqual(0, notifications?.Count);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task DeleteNotificationTest()
        {
            try
            {
                await _notificationService.DeleteAsync(_subscriptionId,33);
                Assert.AreEqual(1,1);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }
    }
}
