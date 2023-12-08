using ProyectoMaui.Service;

namespace ProyectoMaui;

public partial class ComprarPage : ContentPage
{
    private readonly APIService _APIService;

    public ComprarPage(APIService apiservice)
	{
		InitializeComponent();
		_APIService = apiservice;
	}

	private async void OnClickVolver (object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}
