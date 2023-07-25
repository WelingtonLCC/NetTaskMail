
namespace Sender.Domain.Entities
{
    public sealed class SenderConfigDomain
    {
        public int Sender_id { get; private set; }

        public string Sender_user { get; private set; }
        
        public string Sender_smtp { get; private set; } 

        public string Sender_password { get; private set; }

        public string Sender_port { get; private set; }

        public SenderConfigDomain(string sender_user, string sender_smtp, string sender_password, string sender_port)
        {
            ValidateDomain(sender_user, sender_smtp, sender_password, sender_port);
        }

        public SenderConfigDomain(int sender_id, string sender_user, string sender_smtp, string sender_password, string sender_port)
        {
            DomainExceptionValidation.When(sender_id < 0, "Invalid user is required!");
            Sender_id = sender_id;
            ValidateDomain(sender_user, sender_smtp, sender_password, sender_port);
            
        }

        public void Update(string sender_user, string sender_smtp, string sender_password, string sender_port)
        {
            ValidateDomain(sender_user, sender_smtp, sender_password, sender_port);
        }

        private void ValidateDomain(string sender_user, string sender_smtp, string sender_password, string sender_port)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(sender_user), "Invalid user is required!");
            DomainExceptionValidation.When(string.IsNullOrEmpty(sender_smtp), "Invalid smtp is required!");
            DomainExceptionValidation.When(string.IsNullOrEmpty(sender_password), "Invalid password is required!");
            DomainExceptionValidation.When(string.IsNullOrEmpty(sender_port), "Invalid port is required!");

            Sender_user = sender_user;
            Sender_smtp = sender_smtp;
            Sender_password = sender_password; 
            Sender_port = sender_port;
        }

    }
}
