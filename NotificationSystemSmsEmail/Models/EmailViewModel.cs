using System.ComponentModel.DataAnnotations;

namespace NotificationSystemSmsEmail.Models
{
    public class EmailViewModel
    {
        [Required]
        [Display(Name = "Email From")]
        public string EmailFrom { get; set; }

        [Required]
        [Display(Name = "Email To")]
        public string EmailTo { get; set; }

        [Required]
        [Display(Name = "Email Subject")]
        public string EmailSubject { get; set; }

        [Required]
        [Display(Name = "Email Content")]
        public string EmailContent { get; set; }

    }
}