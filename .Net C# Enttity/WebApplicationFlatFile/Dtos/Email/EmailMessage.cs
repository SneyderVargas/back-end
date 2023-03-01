namespace AccountControl.Dtos.Email
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            toAddress = new List<EmailAddres>();
            fromAdress = new List<EmailAddres>();
        }
        public List<EmailAddres> toAddress { get; set; }
        public List<EmailAddres> fromAdress { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
    }
}
