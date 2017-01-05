namespace financeApi.Models
{
    public class Category : Model
    {
        public new string Uuid { get; set; }
        public new string PropertyUuid { get; set; }
        public string CategoryType {get; set;}
        public string Name { get; set; }
        public int Priority { get; set; }
    }
}