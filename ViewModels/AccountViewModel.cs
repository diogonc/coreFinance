namespace CoreFinance.ViewModels
{
    public class AccountViewModel
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public EntityWithUuid Owner { get; set; }
    }
}
