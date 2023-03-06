using Microsoft.Extensions.DependencyInjection;

namespace WestPharma.Views;
public partial class Profile : ContentPage
{
    public Profile(ViewModels.VM_Employee viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}