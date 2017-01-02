namespace NotificationSystemSmsEmail.Models
{
    public class SMS
    {
        public string Numbers { get; set; }

        public string SenderId { get; set; }

        public string Message { get; set; }

        public int Route { get; set; }
    }
}