using System.ComponentModel.DataAnnotations;

namespace NotificationSystemSmsEmail.Models
{
    public class SmsViewModel
    {
        [Required]
        [Display(Name = "SMS Number/Numbers")]
        public string Numbers { get; set; }

        [Required]
        [Display(Name = "SMS SenderID")]
        public string SenderId { get; set; }

        [Required]
        [Display(Name = "SMS Message")]
        public string Message { get; set; }

    }
}