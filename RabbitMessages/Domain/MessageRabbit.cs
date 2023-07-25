namespace RabbitMessages.Domain
{
    public class MessageRabbit
    {
        public int DomainTask_id { get; set; }
        public string Description { get; set; }
        public DateTime OpenIn { get; set; }
        public DateTime Forecast { get; set; }
    }
}
