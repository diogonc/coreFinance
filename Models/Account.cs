namespace financeApi.Models
{
    public class Account : BaseModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Priority {get; set;}
    }
}