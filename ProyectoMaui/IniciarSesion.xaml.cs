using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProyectoMaui.Models;
using ProyectoMaui.Service;

namespace ProyectoMaui;

public partial class IniciarSesion : ContentPage
{
	private readonly APIService _APIService;
	//private readonly UserService _UserService;

	public IniciarSesion(APIService apiservice/*, UserService userservice*/)
	{
		InitializeComponent();
		_APIService = apiservice;
		//_UserService = userservice;
	}

	public async void OnClickIniciarSesion (object sender, EventArgs e)
	{
		string correo = Usuario.Text;
		string contrasena = Contrasena.Text;

        if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(contrasena))
        {
			Usuario usuario = await _APIService.GetIniciarSesion(correo, contrasena);
			if (usuario != null)
			{
				await Navigation.PushModalAsync(new ProductoPage(_APIService));
			}
			else
			{
                var toast = Toast.Make("No se encontró ninguna cuenta, revise sus credenciales.", ToastDuration.Short, 14);
                await toast.Show();
            }
        } else
		{
            var toast = Toast.Make("Por favor, ingrese todos los datos solicitados.", ToastDuration.Short, 14);
            await toast.Show();
        }
    }

	public async void OnClickRegistrarse (object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new RegistrarsePage(_APIService));
	}
}
