namespace AccountControll.Domain.Models
{
    public class Pqr
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Identification { get; set; }
        public string UserCode { get; set; }
        public string NotificationAddress { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Issue { get; set; }
        public string Situation { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<PqrAnnexe> Annexes { get; set; }
        public bool Active { get; set; }

        public string GetSituationDescription()
        {
            return Situation.Equals("A", StringComparison.CurrentCultureIgnoreCase) ? "Arrendatario" : "Propietario";
        }

        public string Autorizo { get; set; }
        public bool Authorizes { get; set; }
        public string Autor { get; set; }
    }
}
