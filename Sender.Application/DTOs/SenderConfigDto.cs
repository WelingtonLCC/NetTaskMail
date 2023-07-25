
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sender.Application.DTOs
{
    public class SenderConfigDto
    {
        public int Sender_id { get; set; }

        [Required(ErrorMessage = "The User is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("User")]
        public string Sender_user { get; set; }

        [Required(ErrorMessage = "The SMTP is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("SMTP")]
        public string Sender_smtp { get; set; }

        [Required(ErrorMessage = "The Message is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Message")]
        public string Sender_password { get; set; }

        [Required(ErrorMessage = "The Port is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Port")]
        public string Sender_port { get; set; }
    }
}
