namespace CoreFinance.ViewModels
{
    public class AccountViewModel
    {
        public string PropertyUuid { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public EntityWithUuid Owner { get; set;}
    }
}
