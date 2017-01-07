namespace financeApi.Models
{
    public class User : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}