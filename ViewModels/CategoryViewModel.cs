namespace CoreFinance.ViewModels
{
    public class CategoryViewModel
    {
        public string PropertyUuid { get; set; }
        public string Name { get; set; }
        public int CategoryType { get; set; }
        public EntityWithUuid Group { get; set; }
        public int Priority { get; set; }
    }
}
