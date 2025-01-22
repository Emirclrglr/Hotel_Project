namespace HotelProject.WebUI.Dtos.ContactDtos
{
    public class ReplyMessageDto
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMail { get; set; }
    }
}
