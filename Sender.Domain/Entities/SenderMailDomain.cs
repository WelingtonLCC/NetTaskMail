
using System.ComponentModel.DataAnnotations.Schema;

namespace Sender.Domain.Entities
{
    public class SenderMailDomain
    {
        public int Sender_id { get; private set; }

        public string Sender_title { get; private set; }

        public string Sender_email { get; private set; }

        public string Sender_message { get; private set; }

        public SenderMailDomain(string sender_title, string sender_email, string sender_message) {
            ValidateDomain(sender_title, sender_email, sender_message);
        }

        public SenderMailDomain(int sender_id, string sender_title, string sender_email, string sender_message)
        {
            DomainExceptionValidation.When(sender_id < 0, "Invalid information ID");
            Sender_id = sender_id;
            ValidateDomain(sender_title, sender_email, sender_message);
        }

        private void ValidateDomain(string sender_title, string sender_email, string sender_message)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(sender_title), "Invalid title is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(sender_email), "Invalid email is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(sender_message), "Invalid message is required");

            Sender_title = sender_title;
            Sender_email = sender_email;
            Sender_message = sender_message;
        }

        public void Update(string sender_title, string sender_email, string sender_message)
        {
            ValidateDomain(sender_title, sender_email, sender_message);
        }

        [NotMapped]
        public SenderConfigDomain senderConfigDomain { get; set; }

    }
}
