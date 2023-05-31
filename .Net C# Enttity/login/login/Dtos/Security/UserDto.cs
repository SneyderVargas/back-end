namespace login.Dtos.Security
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public IList<string> Roles { get; set; }
        public string Version { get; set; }
        public string NumDocument { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        //public string IdRol { get; set; }
        public IList<string> IdRol { get; set; }
        public IList<int> IdCompany { get; set; }
        public long fk_cargo { get; set; }


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

        public string fec_registro_b
        {
            get
            {
                return CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
            }
        }

        public string name_complete_b
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set
            {
            }
        }
    }
}
