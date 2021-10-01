using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
   public class Orden{
       [Key]
       public int IdOrden { get; set; }
  
       public int NumeroOrden { get; set; }
       public DateTime FechaIngreso { get; set; }
       public int IdPaciente { get; set; }
     // public string Nombre { get; set; }
       //public string Apellido { get; set; }
       //public int DNI { get; set; }
       public int IdPractica { get; set; }
       //public int Codigo { get; set; }
       //public string NombrePractica { get; set; }
       public Paciente Paciente { get; set; }
       public Practica Practica { get; set; }
       public List<OrdenDeTrabajo> OrdenDeTrabajo {get;set;}
   }
}


//orden--			
//Idpersona	
//Persona-DNI				
//Persona-apynom		
//Numero Orden		
//FechaIngreso
//IdPracticas
//Practicas-Codigo practica
//Practicas-Nombre Practica