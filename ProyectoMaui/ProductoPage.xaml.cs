using System.Collections.ObjectModel;
using ProyectoMaui.Models;
using ProyectoMaui.Service;

namespace ProyectoMaui;

public partial class ProductoPage : ContentPage
{
    ObservableCollection<Producto> productos;
    private readonly APIService _APIService;

    public ProductoPage(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;

    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<Producto> ListaProductos = await _APIService.GetProductos();
        productos = new ObservableCollection<Producto>(ListaProductos);
        listaProductos.ItemsSource = productos;

        /*var productos = new ObservableCollection<Producto>(Utils.Util.ListaProductos);
        listaProductos.ItemsSource = productos;*/
    }


    private async void OnClickVolver (object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void OnClickComprar (object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ComprarPage(_APIService));
    }

}
