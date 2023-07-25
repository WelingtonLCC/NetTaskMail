namespace RabbitMessages.Domain
{
    public class RabbitMqConfiguration
    {
        public string Host { get; set; }

        public string DefaultUser { get; set; }

        public string DefaultPass { get; set; }

        public int Port { get; set; }
        public string Queue { get; set; }

    }
}
