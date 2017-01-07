namespace financeApi.Models
{
    public class Account : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Priority {get; set;}
    }
}