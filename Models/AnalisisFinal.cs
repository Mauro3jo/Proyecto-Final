using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
   public class AnalisisFinal
   {
       [Key]
       public int IdAnalisisFinal { get; set; } 
      public DateTime FechaEmision { get; set; }
       public int IdOrdenDeTrabajo { get; set; }
  
      public OrdenDeTrabajo OrdenDeTrabajo { get; set; }
      
   }
}