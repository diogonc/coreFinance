namespace financeApi.Models
{
    public class Category : BaseModel
    {
        public string CategoryType {get; set;}
        public string Name { get; set; }
        public int Priority { get; set; }
    }
}