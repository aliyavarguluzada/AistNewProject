namespace AistNewProject.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void CreatePassword(string password)
        {
            string pass = BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor: 13);
            Password = pass;
        }
        public bool VerifyPassword(string password)
        {
            var verifiedPass = BCrypt.Net.BCrypt.EnhancedVerify(password, Password);
            return verifiedPass;
        }
    }
}
