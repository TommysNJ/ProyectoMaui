using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProyectoMaui.Models;
using ProyectoMaui.Service;

namespace ProyectoMaui;

public partial class RegistrarsePage : ContentPage
{
	private readonly APIService _APIService;

	public RegistrarsePage(APIService apiservice)
	{
		InitializeComponent();
		_APIService = apiservice;
	}

	public async void OnClickVolver (object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}

	public async void OnClickCrearCuenta (object sender, EventArgs e)
	{
		string nombre = Nombre.Text;
		string correo = Correo.Text;
		string contrasena = Contrasena.Text;

		if (!string.IsNullOrEmpty( nombre) && !string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(contrasena))
		{
			Usuario usuario = new Usuario
			{
				Nombre = nombre,
				Correo = correo,
				Contrasena = contrasena
			};
			Usuario usuario2 = await _APIService.GetIniciarSesion(correo, contrasena);

			if (usuario2 == null)
			{
                try
                {
                    await _APIService.PostRegistrarse(usuario);
                    await Navigation.PopModalAsync();
                    var toast = Toast.Make("Cuenta creada exitosamente!", ToastDuration.Short, 14);
                    await toast.Show();
                }

                catch (System.Net.WebException ex)
                {
                    // Manejar la excepción aquí o imprimir detalles de la excepción para depuración
                    //Console.WriteLine($"Error al realizar la solicitud: {ex.Message}");
                }
			}
			else
			{
                var toast = Toast.Make("Ya existe una cuenta con ese correo, ingrese otra.", ToastDuration.Short, 14);
                await toast.Show();
            }

        }
		else
		{
            var toast = Toast.Make("Por favor, ingrese todos los datos solicitados.", ToastDuration.Short, 14);
            await toast.Show();
        }
	}
}
