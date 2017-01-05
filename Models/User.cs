namespace financeApi.Models
{
    public class User : Model
    {
        public new string Uuid { get; set; }
        public new string PropertyUuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}