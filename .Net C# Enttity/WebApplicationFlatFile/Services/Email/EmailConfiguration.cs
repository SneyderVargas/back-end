namespace WebApplicationFlatFile.Services.Email
{
    public class EmailConfiguration
    {
        public string smtpServer { get; set; }
        public int smtpPort { get; set; }
        public string stmpUserName { get; set; }
        public string smtpPassword { get; set; }
    }
}
