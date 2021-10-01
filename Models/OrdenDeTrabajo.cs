using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
   public class OrdenDeTrabajo
   {
       [Key]
       public int IdOrdenDeTrabajo { get; set; } 
      public string ValoresDePractica { get; set; }
       public int IdOrden { get; set; }
  //    public string Apellido { get; set;}
    //   public string Nombre { get; set; }
     //  public int DNI { get; set; }
     //  public int Codigo { get; set; }
      // public  string NombrePractica { get; set; }
      public Orden Orden { get; set; }
      public List<AnalisisFinal> AnalisisFinal {get;set;}
   }
}
//Orden de Trabajo--
//IdOrden			
//Orden-Num Orden
//Orden-Persona-Apynom
//Orden-Practic
//Valores a practica