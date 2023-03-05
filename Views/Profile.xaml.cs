namespace WestPharma.Views;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
		this.BindingContext = new ViewModels.VM_Employee(); 
	}
}