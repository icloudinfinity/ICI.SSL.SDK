#nullable disable

namespace ICI.SSL.Core
{
    public class Order
    {
        public string status { get; set; }
        public List<ValidationToken> validationTokens { get; set; }
        public List<Challenge> challenges { get; set; }
        public string orderUri { get; set; }
        public string certificateUri { get; set; }
    }

    public class ValidationToken
    {
        public string tokenName { get; set; }
        public string tokenValue { get; set; }
        public string challengeType { get; set; }
        public string domain { get; set; }
    }

    public class Challenge
    {
        public string challengeType { get; set; }
        public string status { get; set; }
        public string token { get; set; }
    }
}
