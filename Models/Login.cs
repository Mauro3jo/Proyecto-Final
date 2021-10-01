using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Login
   {    [Key]
        public int LoginId { get; set; }
        [Required(ErrorMessage ="Debe ingresar un usuario.")]
        public string Usuario { get; set; }
        
        [Required(ErrorMessage ="Debe ingresar una Contraseña.")]
        public string Password { get; set; }
    }
}