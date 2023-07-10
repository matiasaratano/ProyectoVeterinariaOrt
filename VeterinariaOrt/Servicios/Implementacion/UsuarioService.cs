using VeterinariaOrt.Models;
using VeterinariaOrt.Servicios.Contrato;
using Microsoft.EntityFrameworkCore;
namespace VeterinariaOrt.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly VeterinariaContext _dbContext;
        public UsuarioService(VeterinariaContext dbContext) {
            _dbContext = dbContext;
        }

        //public Task<Usuario> GetUsuario(string mail, string clave)
        //{
        //    Usuario usuarioEncontrado = await _dbContext.Usuarios.Where(u => u.Mail == mail && u.Clave == clave).FirstOrDefaultAsync();
        //    return usuarioEncontrado;
        //}

        public async Task<Usuario> GetUsuario(string mail, string clave)
        {
            Usuario usuarioEncontrado = await _dbContext.Usuario.Where(u=>u.Mail==mail && u.Clave==clave).FirstOrDefaultAsync();

            //ISession session = (ISession)usuarioEncontrado;

            return usuarioEncontrado;

        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuario.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;

        }
    }
}
