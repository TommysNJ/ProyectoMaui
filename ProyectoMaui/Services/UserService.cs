using ProyectoMaui.Models;

namespace ProyectoMaui.Service
{
    public class UserService
    {
        public Usuario usuarioGlobal { get; set; }
        public UserService()
        {
            usuarioGlobal = new Usuario();
        }

    }
}

