
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Sender.Application.DTOs
{
    public class SenderMailDto
    {
        public int Sender_id { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        [MinLength(3)]
        [MaxLength(500)]
        [DisplayName("Title")]
        public string Sender_title { get; set; }

        [Required(ErrorMessage = "The Email is Required")]
        [MinLength(3)]
        [MaxLength(500)]
        [DisplayName("Email")]
        public string Sender_email { get; set; }

        [Required(ErrorMessage = "The Message is Required")]
        [MinLength(3)]
        [MaxLength(500)]
        [DisplayName("Message")]
        public string Sender_message { get; set; }

        [JsonIgnore]
        public SenderConfigDto? SenderConfig { get; set; }

    }
}
