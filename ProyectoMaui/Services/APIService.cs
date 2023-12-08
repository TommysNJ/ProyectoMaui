using ProyectoMaui.Models;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace ProyectoMaui.Service
{
    public class APIService
    {

        public static string _baseUrl;
        public HttpClient _httpClient;

        public APIService()
        {
            _baseUrl = "https://apiproyectomaui.azurewebsites.net";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);

        }


        public async Task<bool> DeleteProducto(int IdProducto)
        {
            var response = await _httpClient.DeleteAsync($"/api/Producto/{IdProducto}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }


        public async Task<Producto> GetProducto(int IdProducto)
        {
            var response = await _httpClient.GetAsync($"/api/Producto/{IdProducto}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto;
            }
            return new Producto();
        }


        public async Task<List<Producto>> GetProductos()
        {
            var response = await _httpClient.GetAsync("/api/Producto");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
                return productos;
            }
            return new List<Producto>();

        }


        public async Task<Producto> PostProducto(Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Producto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }


        public async Task<Producto> PutProducto(int IdProducto, Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Producto/{IdProducto}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }


        public async Task<Producto> PostPro(Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Producto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }


        public async Task<Usuario> GetIniciarSesion(String user, String password)
        {
            var response = await _httpClient.GetAsync($"/api/Usuarios/{user}/{password}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usuario>(json_response);
            }
            return new Usuario();
        }


        public async Task<Usuario> PostRegistrarse(Usuario usuario)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"/api/Usuarios/Registrarse", content);
                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Usuario>(json_response);
                }
                return new Usuario();

            }
            catch (Exception e)
            {

                throw;
            }

        }




        public async Task<List<Compra>> GetCompras()
        {
            var response = await _httpClient.GetAsync("/api/Compra");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Compra>>(json_response);
            }
            return new List<Compra>();
        }


        public async Task<Compra> PostCompra(Compra compra)
        {
            compra.FechaCompra = DateTime.Now;
            var content = new StringContent(JsonConvert.SerializeObject(compra), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Compra", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Compra compraObj = JsonConvert.DeserializeObject<Compra>(json_response);
                return compraObj;
            }
            return new Compra();
        }


        public async Task<bool> DeleteCompra(int IdCompra)
        {
            var response = await _httpClient.DeleteAsync($"/api/Compra/{IdCompra}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }
    }
}
