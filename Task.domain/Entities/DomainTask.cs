

namespace Task.domain.Entities
{
    public sealed class DomainTask
    {
        public int DomainTask_id { get; private set; }
        public string Description { get; private set; }
        public DateTime OpenIn { get; private set; }
        public DateTime Forecast { get; private set; }

        public DomainTask(string description, DateTime openIn, DateTime forecast)
        {
            this.ValidateDomain(description, openIn, forecast);
        }

        public DomainTask(int domainTask_id, string description, DateTime openIn, DateTime forecast)
        {
            DomainExceptionValidation.When(domainTask_id < 0, "Invalid id value");
            this.DomainTask_id = domainTask_id;
            this.ValidateDomain(description, openIn, forecast);
        }

        public void Update(string description, DateTime openIn, DateTime forecast)
        {
            ValidateDomain(description, openIn, forecast);
        }

        private void ValidateDomain(string description, DateTime openIn, DateTime forecast)
        {
           
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description is required!");

            this.Description = description;
            this.OpenIn = openIn;
            this.Forecast = forecast;
        }
    }
}
