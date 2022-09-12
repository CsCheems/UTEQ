using Microsoft.AspNetCore.Identity;

namespace UTEQ.Models
{
    public class UsuarioAplicacion: IdentityUser
    {
        public string NombreCompleto { get; set; } 
    }
}
