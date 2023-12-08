using ProyectoMaui.Models;

namespace ProyectoMaui.Utils
{
    public class Utils
    {

        static public List<Producto> ListaProductos = new List<Producto>()
        {
            new Producto{
                IdProducto=1,
                Nombre="Producto 1",
                Descripcion="Descripcion 1",
                Cantidad=1,
                Precio=1,
            }

        };

        /*static public List<IniciarSesion> iniciarSesions = new List<IniciarSesion>()
        {
            new IniciarSesion{
                Correo="rjuandavid2002@gmail.com",
                Contrasena="El_gatofly2"
            }

        };*/

    }
}
