namespace AccountControll.Domain.Models
{
    public class PqrAnnexe
    {
        public int Id { get; set; }
        public int PqrId { get; set; }
        public string Url { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
