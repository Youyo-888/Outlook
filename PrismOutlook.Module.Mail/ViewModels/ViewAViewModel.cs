using Prism.Mvvm;

namespace PrismOutlook.Module.Mail.ViewModels;

public class ViewAViewModel : BindableBase
{
    private string _message;

    public ViewAViewModel()
    {
        Message = "View A from your Prism Module";
    }

    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }
}