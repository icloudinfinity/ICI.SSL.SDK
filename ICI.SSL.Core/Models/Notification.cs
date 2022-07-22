#nullable disable

namespace ICI.SSL.Core
{
    public class Notification
    {
        public int Id { get; set; }
        public string message { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public int subscriptionId { get; set; }
    }
}
