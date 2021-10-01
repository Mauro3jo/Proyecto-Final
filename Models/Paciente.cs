using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace  Turnos.Models
{
    public class Paciente
    {
      [Key]
      public int IdPaciente {get; set;}
      [Required (ErrorMessage ="debe ingresar un nombre")]
      public string Nombre {get; set;}
     [Required (ErrorMessage ="debe ingresar apellido")]
      public string Apellido {get; set;}
     [Required (ErrorMessage ="debe ingresar DNI")]
      public int DNI { get; set; }
      [Display(Name ="Fecha de Nacimiento")]
      [Required (ErrorMessage ="debe ingresar Fecha de Nacimiento")]
      [DataType (DataType.Date)]
     [DisplayFormat (DataFormatString="{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
      public DateTime FechaNac {get;set;}
     [Required (ErrorMessage ="debe ingresar dirección")]
     [Display(Name ="Dirección")]
      public string Direccion {get; set;}
     [Required (ErrorMessage ="debe ingresar Teléfono")]
     [Display(Name ="Teléfono")]
      public string Telefono {get; set;}

       public List<Orden> Orden {get;set;}
      
    }
}