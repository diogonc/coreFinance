namespace financeApi.Models
{
    public class Account : Model
    {
        public new string Uuid { get; set; }
        public new string PropertyUuid { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Priority {get; set;}
    }
}