namespace AccountControll.Domain.Models
{
    public class CV
    {
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime BirthDate { get; set; }
        public string Profession { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FileUrl { get; set; }
        public IFormFile File { get; set; }
        public string Autorizo { get; set; }
        public bool IsPublic { get; set; }
        public string Autor { get; set; }
    }
}
