using System.ComponentModel.DataAnnotations;

namespace NotificationSystemSmsEmail.Models
{
    public class EmailViewModel
    {
        [Required]
        [Display(Name = "From")]
        public string From { get; set; }

        [Required]
        [Display(Name = "To")]
        public string To { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

    }
}