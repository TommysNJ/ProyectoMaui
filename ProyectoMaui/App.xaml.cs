using ProyectoMaui.Service;

namespace ProyectoMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		APIService apiservice = new APIService();
		//UserService userservice = new UserService();
		MainPage = new NavigationPage(new IniciarSesion(apiservice/*,userservice*/));
	}
}

