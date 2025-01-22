namespace HotelProject.WebUI.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string Subject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }

    }
}
