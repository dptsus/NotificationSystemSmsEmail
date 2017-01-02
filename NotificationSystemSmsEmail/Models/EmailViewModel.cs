using System.ComponentModel.DataAnnotations;

namespace NotificationSystemSmsEmail.Models
{
    public class EmailViewModel
    {
        [Required]
        [Display(Name = "From")]
        public string EmailFrom { get; set; }

        [Required]
        [Display(Name = "To")]
        public string EmailTo { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string EmailSubject { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string EmailContent { get; set; }
    }
}