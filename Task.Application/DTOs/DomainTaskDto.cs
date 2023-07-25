
namespace Task.Application.DTOs
{
    public class DomainTaskDto
    {
        public int DomainTask_id { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        public DateTime OpenIn { get; set; }
        public DateTime Forecast { get; set; }

    }
}
