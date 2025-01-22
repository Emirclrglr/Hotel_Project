namespace HotelProject.WebUI.Dtos.SendMessageDtos
{
    public class CreateSendMessageDto
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMail { get; set; }
        public DateTime SendDate { get; set; }
    }
}
