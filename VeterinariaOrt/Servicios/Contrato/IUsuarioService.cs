using VeterinariaOrt.Models;

namespace VeterinariaOrt.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string mail,string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);

    }
}
