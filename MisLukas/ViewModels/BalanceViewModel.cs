namespace MisLukas.ViewModels;

public class BalanceViewModel : ViewModelBase
{
    public string Text { get; set; }
    
    public BalanceViewModel()
    {
        Text = "Balance General";
    }
}