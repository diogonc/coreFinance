namespace CoreFinance.ViewModels
{
    public class CreatedViewModel
    {
        public string Uuid { get; set; }

        public CreatedViewModel(string uuid)
        {
            Uuid = uuid;
        }
    }
}
