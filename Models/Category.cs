namespace financeApi.Models
{
    public class Category 
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string CategoryType {get; set;}
        public string Name { get; set; }
        public int Priority { get; set; }
    }
}