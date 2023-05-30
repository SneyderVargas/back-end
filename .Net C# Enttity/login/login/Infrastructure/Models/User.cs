namespace login.Infrastructure.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string PhoneNumber { get; set; }
        public IList<string> Roles { get; set; }
        public string NumDocument { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        //public string IdRol { get; set; }
        public IList<string> IdRol { get; set; }
        //public int IdCompany { get; set; }
        public IList<int> IdCompany { get; set; }
        public string IdUser { get; set; }
        //public Array IdCompanys { get; set; }


        public string estado_b
        {
            get
            {
                return Active ? "SI" : "NO";
            }
            set
            {
            }
        }

        public long fk_cargo { get; set; }
    }
}
