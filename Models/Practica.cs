using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
   public class Practica{
       [Key]
       public int IdPractica { get; set; }
       [Required (ErrorMessage ="Debe ingresar una Codigo")]
       public int Codigo { get; set; }
       [Required (ErrorMessage ="Debe ingresar una Nombre para la practica")]
       public string NombrePractica { get; set; }
       
       public List<Orden> Orden {get;set;}
      
      
   }
}